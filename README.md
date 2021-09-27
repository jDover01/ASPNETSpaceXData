# ASPNETSpaceXData

ASPNETApaceXData project changes to fix Bugs & add features

BUGS
1) Code Behind in Default.aspx.cs, inside the method RadGrid1_InsertCommand there was a compilation error because the project was using the wrong reference to Telerik's RadCombobox.
2) In the same method, to fix the second bug, I changed the values inserted to lastName for the LastName field. This fixed the issue of using the firstName value on the LastName field
when inserting new records.
3) Table was not ordered alphabetically by lastName. Updated to sort by last name.

FEATURES
1) Added support for Yelllow as a favorite color
  Added else if condition in RadGrid1_InsertCommand method for the color Yellow. This allows the color Yellow to be inserted into the database.
  Added RadComboBoxItem to the GridTemplateColumn for the color Yellow
  Added RadComboBoxItem to the FilterTemplate for the color Yellow
  
