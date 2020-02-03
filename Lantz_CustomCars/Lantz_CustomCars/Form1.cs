using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
/*Steven Lantz
*ITDEV-185-900
*Spring 2020
*Assignment #1: Custom Cars*/

namespace Lantz_CustomCars
{
    public partial class Form1 : Form
    {

        Random rnd = new Random();//Random object to generate ID numbers
        Prices price = new Prices();//Price object to set prices based on car options
        Honda newCar;
        List<Customer> customerList = new List<Customer>();//Array list to hold Customer objects
        List<Honda> hondaList = new List<Honda>();//Array list to hold Honda objects

        int totalPrice = 0;//Hold price value to be passed to customer object
        string fileName = "CustomerOrder.txt";
      
        int index;
        
        public Form1()
        {
            InitializeComponent();
        }

        //Load form
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        //Submit button clicked
        //Holds majority of logic
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if(radEnterNew.Checked == false && radSearch.Checked == false)
            {
                MessageBox.Show("Please choose Search or Enter New Customer");
            }
//Enter a new customer option chosen
            if (radEnterNew.Checked)
            {
                
                //Check if any controls are left blank
                //Program will not contiue if a control is blank
                if (String.IsNullOrEmpty(txtFName.Text))
                {
                    MessageBox.Show("Please enter a first name");
                    return;
                }

                if (String.IsNullOrEmpty(txtLName.Text))
                {
                    MessageBox.Show("Please enter a last name");
                    return;
                }

                //Check for correct number of digits in phone number or if form is blank
                if (txtPhoneNumber.Text.Length > 12 || txtPhoneNumber.Text.Length < 12
                     || String.IsNullOrEmpty(txtPhoneNumber.Text))
                {
                    MessageBox.Show("Please enter phone number as XXX-XXX-XXXX");
                    return;
                }

                if (String.IsNullOrEmpty(txtAddress.Text))
                {
                    MessageBox.Show("Please enter an address");
                    return;
                }

                if (String.IsNullOrEmpty(txtCity.Text))
                {
                    MessageBox.Show("Please enter a city");
                    return;
                }

                //Check for two letters in state or form left blank
                if (txtState.Text.Length > 2 || txtState.Text.Length < 2 || String.IsNullOrEmpty(txtState.Text))
                {
                    MessageBox.Show("Please enter only two letters for state");
                    return;
                }

                //Check for correct number of digits in zipcode
                if (txtZipCode.Text.Length > 5 || txtZipCode.Text.Length < 5 || String.IsNullOrEmpty(txtZipCode.Text))
                {
                    MessageBox.Show("Please enter a valid zipcode");
                    return;
                }

//Check if car options selected
                if (cmbAmenities.SelectedIndex == -1)
                {
                    MessageBox.Show("Please choose an amenity");
                    return;
                }

                if(cmbEngine.SelectedIndex == -1)
                {
                    MessageBox.Show("Please choose an engine type");
                    return;
                }

                if (cmbModel.SelectedIndex == -1)
                {
                    MessageBox.Show("Please choose a model");
                    return;
                }

                if (cmbType.SelectedIndex == -1)
                {
                    MessageBox.Show("Please choose a type");
                    return;
                }

                if (cmbYear.SelectedIndex == -1)
                {
                    MessageBox.Show("Please choose a year");
                    return;
                }
               
//Total price based on options chosen
                if (cmbAmenities.SelectedItem.Equals("Luxury"))
                    totalPrice += price.LUXURY1;

                if (cmbAmenities.SelectedItem.Equals("Standard"))
                    totalPrice += price.STANDARD1;

                if (cmbEngine.SelectedItem.Equals("V6"))
                    totalPrice += price.V61;

                if (cmbEngine.SelectedItem.Equals("V4"))
                    totalPrice += price.V41;

                if (cmbModel.SelectedItem.Equals("Civic"))
                    totalPrice += price.CIVIC1;

                if (cmbModel.SelectedItem.Equals("Accord"))
                    totalPrice += price.ACCORD1;

                if (cmbType.SelectedItem.Equals("Coupe"))
                    totalPrice += price.COUPE1;

                if (cmbType.SelectedItem.Equals("Sedan"))
                    totalPrice += price.SEDAN1;

                //Create new customer object from form inputs
                Customer cust = new Customer(txtFName.Text.ToUpper(), txtLName.Text.ToUpper(), 
                                                                                txtPhoneNumber.Text, GenerateIDNumber(), totalPrice, 
                                                                                txtAddress.Text.ToUpper(), txtCity.Text.ToUpper(), 
                                                                                txtState.Text.ToUpper(),
                                                                                txtZipCode.Text);

                //Create Honda object based on luxury model selected
                //Couldn't figure out how to set the enum from the combo box choice
                if (cmbAmenities.SelectedItem.Equals("Luxury"))
                {
                    newCar = new Honda(cmbType.Text, Int16.Parse(cmbYear.Text),
                                                                        Honda.LuxuryorStandard.Luxury, cmbModel.Text,
                                                                        cmbEngine.Text);
                }

                //Create Honda object based on standard model selected
                if (cmbAmenities.SelectedItem.Equals("Standard"))
                {
                    newCar = new Honda(cmbType.Text, Int16.Parse(cmbYear.Text),
                                                                        Honda.LuxuryorStandard.Standard, cmbModel.Text,
                                                                       cmbEngine.Text);
                }

                

                //Write customer and honda object to file
                try
                {
                    using (StreamWriter writeFile = new StreamWriter(fileName, true))//Write to file; true means append
                    {
                        writeFile.WriteLine(cust.ToString());
                        writeFile.WriteLine(newCar.ToString());
                    }
                }
                catch (System.IO.DirectoryNotFoundException ex)
                {
                    MessageBox.Show(ex.Message);
                }

                //Read file to list box to display to user
                try
                {
                    using (StreamReader stRead = new StreamReader(fileName))
                    {
                        while (!stRead.EndOfStream)
                        {
                            lstbxReceipt.Items.Add(stRead.ReadLine());
                        }
                    }
                }
                catch (System.IO.DirectoryNotFoundException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                totalPrice = 0;
                //clearForm();
            }//End of enter new customer radio button

            if (radSearch.Checked)
            {
                searchFile(txtLName.Text);
            }//End of search radio button

        }//End of button submit

        //Create id number; uses random generator
        public int GenerateIDNumber()
        {
            int idNumber = rnd.Next(1000, 9000);

            return idNumber;
        }

        //Display my info
        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Name:\t\tSteven Lantz" +
                                                  "\nCourse:\t\tITDEV-185-900" +
                                                   "\nInstructor:\tMark Cribb" +
                                                   "\nAssignment:\t#1 Custom Cars" +
                                                   "\nDate:\t\t" + System.DateTime.Now);

        }
        
        //Clear form chosen from menu
        private void clearFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clearForm();
        }
        
        //Exit chosen from file menu
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Clears all controls in form
        public void clearForm()
        {
            txtCity.Clear();
            txtAddress.Clear();
            txtFName.Clear();
            txtLName.Clear();
            txtPhoneNumber.Clear();
            txtState.Clear();
            txtZipCode.Clear();

            cmbAmenities.SelectedIndex = -1;
            cmbEngine.SelectedIndex = -1;
            cmbModel.SelectedIndex = -1;
            cmbType.SelectedIndex = -1;
            cmbYear.SelectedIndex = -1;

            lstbxReceipt.Items.Clear();

        
            radEnterNew.Checked = false;
            radSearch.Checked = false;
        }

//Search file for a record based on customer last name
       public void searchFile(string custLastName)
        {
            if (File.Exists(fileName))
            {
                try
                {
                    using (StreamReader inFile = File.OpenText(fileName))
                    {
                        //Read all lines from file into customer and honda objects
                        while (inFile.Peek() > 0)
                        {
                            Customer cust = new Customer();//Create new customer object
                            //Read lines into Customer object
                            cust.FirstName = inFile.ReadLine();
                            cust.LastName = inFile.ReadLine();
                            cust.PhoneNumber = inFile.ReadLine();
                            cust.Address = inFile.ReadLine();
                            cust.City = inFile.ReadLine();
                            cust.State = inFile.ReadLine();
                            cust.ZipCode = inFile.ReadLine();
                            cust.IdNumber = int.Parse(inFile.ReadLine().Trim());
                            cust.Price = int.Parse(inFile.ReadLine());

                            customerList.Add(cust);//Add object to array list
                     
                            
                            Honda honda = new Honda();//Create new Honda object
                                                      //Read lines into Honda object
                            honda.CarManufacturer = inFile.ReadLine();
                            honda.Model = inFile.ReadLine();
                            honda.EngineType = inFile.ReadLine();
                            honda.Amenity = inFile.ReadLine();
                            honda.CarType = inFile.ReadLine();
                            honda.CarYear = int.Parse(inFile.ReadLine());

                            hondaList.Add(honda);//Add object to array list
                        }
                            for (int i = 0; i <customerList.Count; i++)
                            {
                                if (customerList[i].LastName.Equals(txtLName.Text.ToUpper()))
                                {
                                    index = i;
                               
                                 

                                    lstbxReceipt.Items.Add(customerList[index].FirstName);
                                    lstbxReceipt.Items.Add(customerList[index].LastName);
                                    lstbxReceipt.Items.Add(customerList[index].IdNumber);
                                    lstbxReceipt.Items.Add(customerList[index].PhoneNumber);
                                    lstbxReceipt.Items.Add(customerList[index].Address);
                                    lstbxReceipt.Items.Add(customerList[index].City);
                                    lstbxReceipt.Items.Add(customerList[index].State);
                                    lstbxReceipt.Items.Add(customerList[index].ZipCode);

                                    lstbxReceipt.Items.Add(hondaList[index].CarManufacturer);
                                    lstbxReceipt.Items.Add(hondaList[index].CarType);
                                    lstbxReceipt.Items.Add(hondaList[index].CarYear);
                                    lstbxReceipt.Items.Add(hondaList[index].EngineType);
                                    lstbxReceipt.Items.Add(hondaList[index].Amenity);
                                break;
                   

                                }
                               
                              
                            }
                      



                    }
                    
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    throw;
                }
            }
            else
            {
                MessageBox.Show("File does not exist");
            }
          
        }//End of searchFile

//Delete a record
//Ran out of time to add this feature


    }//End of class
}//End of namespace
