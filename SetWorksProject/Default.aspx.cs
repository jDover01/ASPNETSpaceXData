using System;
using System.Web.UI.WebControls;
using System.Configuration;
using Telerik.Web.UI;
using System.Data.SqlClient;
using System.Runtime;

public partial class Default : System.Web.UI.Page
{
    SqlConnection SqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
    public SqlCommand SqlCommand = new SqlCommand();

    protected void RadGrid1_InsertCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
    {
        //Get the GridEditFormInsertItem of the RadGrid    
        GridEditFormInsertItem insertedItem = (GridEditFormInsertItem)e.Item;

        string FirstName = (insertedItem["FirstName"].Controls[0] as TextBox).Text;
        string LastName = (insertedItem["LastName"].Controls[0] as TextBox).Text;
        bool Chocolate = (e.Item.FindControl("CheckBox1") as CheckBox).Checked;
        RadComboBox combo = (RadComboBox)e.Item.FindControl("RadComboBox1");
        var Colors = combo.CheckedItems;
        System.Text.StringBuilder ColorString = new System.Text.StringBuilder();
        int i = 0;
        foreach (var item in Colors)
        {
            if (i != 0)
            {
                ColorString.Append(", ");
            }
            if (item.Value == "Blue")
            {
                ColorString.Append("Blue");
            }
            else if (item.Value == "Green")
            {
                ColorString.Append("Green");
            }
            
            else if (item.Value == "Red")
            {
                ColorString.Append("Red");
            }
            else if (item.Value == "Purple")
            {
                ColorString.Append("Purple");
            }
            //add support for the color yellow
            else if (item.Value == "Yellow")
            {
                ColorString.Append("Yellow");
            }

            i++;
        }

        string PreferredColors = ColorString.ToString();

          try
          {
              //Open the SqlConnection    
              SqlConnection.Open();
              //Update Query to insert into  the database     
              string insertQuery = "INSERT INTO PatientInfo(FirstName, LastName, Chocolate, PreferredColors) VALUES('" + FirstName + "','" + LastName + "','" + Chocolate + "','" + PreferredColors + "')";
              SqlCommand.CommandText = insertQuery;
              SqlCommand.Connection = SqlConnection;
              SqlCommand.ExecuteNonQuery();
              //Close the SqlConnection    
              SqlConnection.Close();
              e.Canceled = true;
              RadGrid1.MasterTableView.IsItemInserted = false;
              RadGrid1.Rebind();



          }
          catch (Exception ex)
          {
          }
    }

    /* protected void CheckChanged(Object sender, EventArgs e)
     {
         foreach (GridDataItem item in RadGrid1.SelectedItems)
         {
             string Id = item["Id"].Text;
             bool Chocolate = item["Chocolate"].Text;
         }
     }*/
    protected void CheckChanged(object sender, EventArgs e)
    {
        
        ((sender as Telerik.Web.UI.RadCheckBox).NamingContainer as GridItem).Selected = true;
        RadCheckBox chkbx = sender as RadCheckBox;
        foreach (GridDataItem item in RadGrid1.SelectedItems)
        {
            string IdString = item["Id"].Text;
            int PatientId = Int32.Parse(IdString);
            string ChocolateString = Convert.ToString(chkbx.Checked);
            bool ChocolatePref = Convert.ToBoolean(ChocolateString);


            try
            {
                //Open the SqlConnection    
                SqlConnection.Open();
                //Update Query to insert into  the database     
                string updateQuery = "UPDATE PatientInfo SET Chocolate= '" + ChocolatePref + "' WHERE Id= '" + PatientId + "'";
                SqlCommand.CommandText = updateQuery;
                SqlCommand.Connection = SqlConnection;
                SqlCommand.ExecuteNonQuery();
                //Close the SqlConnection    
                SqlConnection.Close();
                RadGrid1.Rebind();
                RadGrid1.SelectedIndexes.Clear();



            }
            catch (Exception ex)
            {
                RadGrid1.Rebind();
                RadGrid1.SelectedIndexes.Clear();
            }
        }      
    }
}
