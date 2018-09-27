# CoverageConverter
Converts VSTest files to emma.xsl

How to use:
run command from your a folder containing a sub directory with your VSTest results. This folder is usually named: <accountName>_<computerName>_<dateTime-of-creation>
run CoverageConverter.exe with one parameter: a substring matching the folder in which your VStest files are located. 
  
  
  
  
  
EG.

//-------directory structure -----------------

Testresults
  -> Joshuavandenbor_TI803HDJ90_2018-09-27_16_21_01
    -> IN
      -> TI803HDJ90_2018
        -> Joshuavandenbor_TI803HDJ90_2018-09-27_16_21_01.coverage
      
  -> other directories
  
 //------------------------------------------- 
 //---------command---------------------------
 
 ~$ CoverageConverter.exe Joshuavandenbor_TI803HDJ90
 
 ///-----------------------------------------
