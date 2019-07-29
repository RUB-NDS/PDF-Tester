#!/bin/bash

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

# Approval file Visible with a predefined image
java -jar pdfsigner.jar -i document.pdf -o approval_visible_custom_img.pdf -pkcs demo-rsa2048.p12 -sigtype approval -sigview visible -p demo-rsa2048

# Approval file Visible with a custom image
java -jar pdfsigner.jar -i document.pdf -o approval_visible.pdf -pkcs demo-rsa2048.p12 -sigtype approval -sigview visible -p demo-rsa2048 -sigimg PdfInsecurityTeam-Logo.png

# Approval file Invisible
java -jar pdfsigner.jar -i document.pdf -o approval_invisible.pdf -pkcs demo-rsa2048.p12 -sigtype approval -sigview invisible -p demo-rsa2048