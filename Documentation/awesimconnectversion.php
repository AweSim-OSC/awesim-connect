<?php

  /*
   * Brian McMichael
   * bmcmichael@osc.edu
   *
   * This file contains the method GetFileVersion, which will read the application headers
   * of a Windows file on a system and return an array of the Windows assembly file version
   * embedded in the file. This file will work unmodified if it is deployed in a public
   * location beside the deployed file.
   *
   * Method returns format: GetFileVersion(File) => [ (int)Major, (int)Minor, 0, 0 ]
   * Additional code block at the bottom formats the output for the AweSim Connect app.
   *
   * If the hosted file location is different than the location of the php file, update the
   * $AweSimConnectFile variable to list the path to the deployed file.
   *
   * The location of the .php file is hard-coded into /Controllers/VersionChecker.cs
   * If the php file is moved, the app will need to be updated with the new location.
   *
   * Currently:
   *    public static string VERSION_RESPONSE_PAGE =
   *      @"https://apps.awesim.org/assets/wiag/connect/latest/awesimconnectversion.php";
   *
   * If the file is moved or the php response is not found by the application, the app will
   * move on gracefully but will not notify the user of updates.
   */
  
  $AweSimConnectFile = "AweSimConnect.exe";
  
  function GetFileVersion($FileName) {

    $handle=fopen($FileName,'rb');
    if (!$handle) return FALSE;
    $Header=fread ($handle,64);
    if (substr($Header,0,2)!='MZ') return FALSE;
    $PEOffset=unpack("V",substr($Header,60,4));
    if ($PEOffset[1]<64) return FALSE;
    fseek($handle,$PEOffset[1],SEEK_SET);
    $Header=fread ($handle,24);
    if (substr($Header,0,2)!='PE') return FALSE;
    $Machine=unpack("v",substr($Header,4,2));
    if ($Machine[1]!=332) return FALSE;
    $NoSections=unpack("v",substr($Header,6,2));
    $OptHdrSize=unpack("v",substr($Header,20,2));
    fseek($handle,$OptHdrSize[1],SEEK_CUR);
    $ResFound=FALSE;
    for ($x=0;$x<$NoSections[1];$x++) {      //$x fixed here
        $SecHdr=fread($handle,40);
        if (substr($SecHdr,0,5)=='.rsrc') {         //resource section
            $ResFound=TRUE;
            break;
        }
    }
    if (!$ResFound) return FALSE;
    $InfoVirt=unpack("V",substr($SecHdr,12,4));
    $InfoSize=unpack("V",substr($SecHdr,16,4));
    $InfoOff=unpack("V",substr($SecHdr,20,4));
    fseek($handle,$InfoOff[1],SEEK_SET);
    $Info=fread($handle,$InfoSize[1]);
    $NumDirs=unpack("v",substr($Info,14,2));
    $InfoFound=FALSE;
    for ($x=0;$x<$NumDirs[1];$x++) {
        $Type=unpack("V",substr($Info,($x*8)+16,4));
        if($Type[1]==16) {             //FILEINFO resource
            $InfoFound=TRUE;
            $SubOff=unpack("V",substr($Info,($x*8)+20,4));
            break;
        }
    }
    if (!$InfoFound) return FALSE;
    $SubOff[1]&=0x7fffffff;
    $InfoOff=unpack("V",substr($Info,$SubOff[1]+20,4)); //offset of first FILEINFO
    $InfoOff[1]&=0x7fffffff;
    $InfoOff=unpack("V",substr($Info,$InfoOff[1]+20,4));    //offset to data
    $DataOff=unpack("V",substr($Info,$InfoOff[1],4));
    $DataSize=unpack("V",substr($Info,$InfoOff[1]+4,4));
    $CodePage=unpack("V",substr($Info,$InfoOff[1]+8,4));
    $DataOff[1]-=$InfoVirt[1];
    $Version=unpack("v4",substr($Info,$DataOff[1]+48,8));
    $x=$Version[2];
    $Version[2]=$Version[1];
    $Version[1]=$x;
    $x=$Version[4];
    $Version[4]=$Version[3];
    $Version[3]=$x;
    return $Version;
  }

  // This is required for proper formatting of the string for the app parser.
  // Output Example: 0.70.0.0
  $isFirst = true;
  foreach (GetFileVersion($AweSimConnectFile) as $subvers) {
    if ($isFirst) {
            $isFirst = false;
            echo $subvers;
            continue;
    }
    echo ".".$subvers;
  }

?>