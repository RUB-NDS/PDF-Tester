# PDF Tester

## Executable program
PdfTester.exe

## Tesseract
Tesseract can be downloaded here: https://github.com/UB-Mannheim/tesseract/wiki <br/>
It is sufficient to unpack the downloaded archive. No installation is required.

## Language packages
Tesseract language packages can be downloaded here: https://github.com/tesseract-ocr/tessdata_best <br/>
Move the language files to the "Tesseract\tessdata\" folder.

## Functions
-Automatically launch PDF applications with PDF document and create screenshots<br/>
-Compare screenshots<br/>
-OCR text recognition of screenshots<br/>

## Storage location
-Settings and inputs are stored in configuration files under "C:\Users\%USERNAME%\AppData\Local\PdfTester\".<br/>
-Erros are stored in a debug file under "C:\Users\%USERNAME%\AppData\Local\PdfTester\".

## [Creator]
List of PDF applications:<br/>
Enter the paths to each PDF application (one path per line).
Optionally, a name can be selected by entering a semicolon + following string.
This name will be used as file name to the corresponding screenshot.
If no name is specified, the file name of the PDF application will be used.
In addition to the name, a waiting time can be entered by entering another semicolon followed by an integer value.
Since PDF applications need different amounts of time to display the contents of a PDF document, a waiting time can be entered here individually for each PDF viewer.
Only after this waiting time a screenshot is made and the program is closed.
If no waiting time is specified, the waiting time under [Settings] is used.
<br/><br/>
Path to the PDF documents to be checked:<br/>
At this point the folder to the PDF files must be specified (subfolders are considered).
The individual files are added as an argument to the program start of the viewing programs.
<br/><br/>
Path to the screenshots to be created:<br/>
At this point, the folder where the created screenshots should be saved must be selected.
A subfolder is created for each PDF application.
<br/><br/>
Launch Screenshot Creator:<br/>
This button starts the processing.
Each PDF document found under the selected path, will be called with each PDF application in the program list.
Then a screenshot is created and saved under the selected location.
The file name of the screenshot is composed as follows "PDF file name + _ + name in program list + _ + date + .png".
<br/><br/>
Save inputs:<br/>
Saves the program list, as well as the path information.
<br/><br/>
Open debug file:<br/>
Opens the debug file from which further information can be taken in the event of an error.


## [Comparer]
Here you can compare different screenshots using reference screenshots.
Since in each case pixel is compared with pixel, the screenshots to be compared must have the same pixel width.
<br/><br/>
Path to the screenshots of PDF documents to be checked:<br/>
The path to the screenshots created under [Creator] must be entered here (subfolders are taken into account).
<br/><br/>
Path to the screenshots of valid PDF documents:<br/>
Reference screenshots must be created under [Creator], which have a valid signature verification.
These screenshots serve as a reference and are to be compared with screenshots of the PDF documents to be checked.
Subfolders are included when defining the path.
<br/><br/>
Launch Screenshot Comparer:<br/>
This button starts the processing.
The program reads the file names in the defined folders and compares the contained name of the PDF viewing program.
It searches for a matching valid screenshot for the screenshot to be checked (e.g. both screenshots were created with Acrobat Reader DC, so the file name contains "AdobeDC".).
If a matching valid screenshot is found, both screenshots are compared.
If there is no pixel difference, it can be concluded that the content is the same and therefore the screenshot to be checked has a valid signature check.
The results are output in the two text boxes.


## [OCR Analyzer]
At this point, screenshots can be read in via OCR text recognition and the content searched for unique search terms.
Tesseract is used for text recognition.
<br/><br/>
Path to the screenshots of PDF documents to be checked:<br/>
The path to the screenshots created under [Creator] must be entered here (Subfolders are included).
<br/><br/>
Path to save the recognized text to a file:<br/>
The content of the screenshots scanned via OCR text recognition is written to the text file for later evaluation.
<br/><br/>
Search terms:<br/>
The term to be searched must be entered in this text field. Ex. "signature is valid".
The program will search the scanned content for the entered search terms and display them in the corresponding text box.
<br/><br/>
Perform OCR text recognition additionally with grayscale screenshot:<br/>
To improve text recognition, converting the screenshot to grayscale can be beneficial. 
Perform OCR text recognition additionally with upscaled screenshot:<br/>
It may happen that the screenshot quality is not sufficient to achieve an optimal result in text recognition.
By a second run with an upscaled screenshot, the text recognition can be improved.
These options extends the processing time per image by a factor of about 2.5.


## [Settings]
Waiting time before closing the PDF application:<br/>
Depending on the processing power and PDF application, it may take a while until the PDF application has completely loaded the PDF file.
Only after this waiting time, the screenshot [Creator] is made.
Default value: 50 seconds
<br/><br/>
Waiting time after the PDF application was closed:<br/>
Depending on the processing power and application, it may take a moment until the PDF application is completely closed by the PDF Tester.
Only after this waiting time, the next PDF application will be launched.
Default value: 2 seconds
<br/><br/>
Difference limit for successful screenshot comparison:<br/>
During screenshot comparison [Comparer], minimal pixel deviations may occur, although the screenshot to be checked has a valid signature check.
The maximum deviation can be adjusted at this point.
Default value: 0.00001 %
<br/><br/>
Maximum image height to consider for screenshot comparison:<br/>
The relevant image section in the screenshot comparison [Comparer], which has a valid or an invalid signature check, is usually located in the upper image area.
To speed up the screenshot comparison, the image area to be considered can be restricted.
Default value: 500 pixels
<br/><br/>
Language selection OCR text recognition:<br/>
A language pack can be selected for the text recognition.
It is recommended to create the screenshots in english and to select the english language package "eng", because the best results could be achieved with it. The dropdown list is filled with the files in the "tessdata" subfolder of the Tesseract folder. The language files must have the extension ".traineddata".
<br/><br/>
Path to the Tesseract folder:<br/>
At this point, the Tesseract program folder must be selected.
Inside the Tesseract folder, the language packages must be located in the "tessdata" folder.
