#!/bin/bash
#######################################################
############ DOCMDP SECTION ###########################
#######################################################
#Certify file visible with a predefined image
java -jar pdfsigner.jar -i document.pdf -o certified_visible.pdf -pkcs demo-rsa2048.p12 -sigtype certified -sigview visible -p demo-rsa2048

#Certify file visible with a custom image
java -jar pdfsigner.jar -i document.pdf -o certified_visible_custom_img.pdf -pkcs demo-rsa2048.p12 -sigtype certified -sigview visible -p demo-rsa2048 -sigimg PdfInsecurityTeam-Logo.png

# Certify file Invisible
java -jar pdfsigner.jar -i document.pdf -o certified_invisible.pdf -pkcs demo-rsa2048.p12 -sigtype certified -sigview invisible -p demo-rsa2048

# Certify file Visible Locked with a predefined image
java -jar pdfsigner.jar -i document.pdf -o certified_visible_locked.pdf -pkcs demo-rsa2048.p12 -sigtype certified -sigview visible -p demo-rsa2048 -lock true

# Certify file Invisible Locked
java -jar pdfsigner.jar -i document.pdf -o certified_invisible_locked.pdf -pkcs demo-rsa2048.p12 -sigtype certified -sigview invisible -p demo-rsa2048 -lock true

#######################################################
############ DOCMDP SECTION ###########################
#######################################################
# Approval file Visible with a predefined image
java -jar pdfsigner.jar -i document.pdf -o approval_visible_custom_img.pdf -pkcs demo-rsa2048.p12 -sigtype approval -sigview visible -p demo-rsa2048

# Approval file Visible with a custom image
java -jar pdfsigner.jar -i document.pdf -o approval_visible.pdf -pkcs demo-rsa2048.p12 -sigtype approval -sigview visible -p demo-rsa2048 -sigimg PdfInsecurityTeam-Logo.png

# Approval file Invisible
java -jar pdfsigner.jar -i document.pdf -o approval_invisible.pdf -pkcs demo-rsa2048.p12 -sigtype approval -sigview invisible -p demo-rsa2048

#######################################################
############ FIELDMDP SECTION #########################
#######################################################

# FieldMDP Protecting all fields: Action=All
java -jar pdfsigner.jar -i document_fields.pdf -o signed_fieldmdp_all.pdf -pkcs demo-rsa2048.p12 -password demo-rsa2048 -sigtype certified -transform fieldmdp -fieldmpd_action action -sigview visible -sigimg PdfInsecurityTeam-Logo.png

# FieldMDP Protecting including fields: Action=Include, Fields=Text1,Text2
java -jar pdfsigner.jar -i document_fields.pdf -o signed_fieldmdp_included.pdf -pkcs demo-rsa2048.p12 -password demo-rsa2048 -sigtype certified -transform fieldmdp -fieldmpd_action include -fieldmpd_fields Text1,Text2 -sigview visible -sigimg PdfInsecurityTeam-Logo.png

# FieldMDP Protecting including fields: Action=Exclude, Fields=Text1
java -jar pdfsigner.jar -i document_fields.pdf -o signed_fieldmdp_excluded.pdf -pkcs demo-rsa2048.p12 -password demo-rsa2048 -sigtype certified -transform fieldmdp -fieldmpd_action include -fieldmpd_fields Text1 -sigview visible -sigimg PdfInsecurityTeam-Logo.png


#######################################################
############ UR3 SECTION #########################
#######################################################
-i document_fields.pdf -o signed_ur3.pdf -pkcs demo-rsa2048.p12 -password demo-rsa2048 -sigtype certified -transform ur3 -sigview visible -sigimg PdfInsecurityTeam-Logo.png