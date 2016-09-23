# BrewAuthorMerge
Program to merge ACP author files. 

Use the setup.exe to install the program. This also allows uninstall.

The help file BrewAuthorMerge.chm describes how to use the various functions.

# Background

ACP provides a web based interface for users to control their observatory. The user may modify the vanilla interface to add new functionality, change system provided stubs to fill in information. These changes are accomplished by going into "Authoring Mode" in the browser and modifying the author.html file.

Unfortunately, when ACP is updated it cannot determine changes made by the user and how to merge them into the vanilla author.html file. In this situation, the ACP update process backs up the current author.html (containing custom modifications) to something like
       DocRoot/author-backup/author.bk-20160517_061009.html. 
ACP then installs the standard author.html, which may contain changes related to this update.

BrewAuthorMerge is intended to merge the custom changes in author.bk-20160517_061009.html into the new author.html. Historically the user needed to run diff and manually copy entries. Unfortunately 

a) the file is tough to read, and 
b) the MainMenu tiddler has to be handled separately. If the user modifies the MainMenu tiddler, he should manually make a separate copy at that time to more easily do the diffs.

Note that after the merge is completed, the user needs to go into author mode and save the file to the web. This step updates the index.asp file to reflect the merged author.html file.
