# ASPNETSpaceXData

ASPNETApaceXData project changes to fix Bugs & add features

Default.aspx

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
  

  
SpaceXData.aspx is the second portion of the assessment. Create a website that shows SpaceXData with requirements below.

* Display the date and time of each mission, the rocket name, and whether the launch was a success.
* Display the time of the mission in Central Time (CT)
* Order the launches in reverse chronological order
* For each launch, include a column that ranks the payload mass, with the heaviest payload being rank 1

COMMENTS
I addeded comments in the code to show some of the struggles I had with ASP.NET Web Forms and the Telerik product. 
The Telerik grid would not perform sorting correctly until I added the event for the OnNeedDataSource. I did try to use Telerik as I had in the past, using javascript to populate
grid datasource, but it did not work right away. 
