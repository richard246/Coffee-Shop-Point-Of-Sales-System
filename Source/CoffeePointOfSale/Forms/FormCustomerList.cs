﻿using CoffeePointOfSale.Configuration;
using CoffeePointOfSale.Forms.Base;
using CoffeePointOfSale.Services.Customer;
using CoffeePointOfSale.Services.FormFactory;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CoffeePointOfSale.Forms;

public partial class FormCustomerList : FormNoCloseBase
{
    public static string customerName;
    public static int customerIndex;
    public static Customer cCustomer;
    private readonly ICustomerService _customerService;
   
    public FormCustomerList(IAppSettings appSettings, ICustomerService customerService) : base(appSettings)
        
            {
            _customerService = customerService;
            InitializeComponent();
        //not useful now but it shows how to add a customer to the customerlist 
        _customerService.Customers.Add(new Customer() { Phone = "908-808-7890", Name = "jill hill", RewardPoints = 0 });
        
        foreach (Customer elem in _customerService.Customers.List)
        {
        
            customerBindingSource.Add(elem);

        }
        
    }
        private void FormCustomerList_Load(object sender, EventArgs e)
        {
       
        
    }

    private void button1_Click(object sender, EventArgs e)
    {
        FormCustomizations.addToRecipt.Clear();
        FormOrder.subtotal = 0;
        FormOrder.finalReceipt = "";
        FormCustomizations.subTotal = 0;
        FormCustomerList.customerName = "";
        FormCustomizations.addToRecipt.Clear();
        FormCustomerList.customerName = "Anonymous";
        Close(); //closes this form
        FormFactory.Get<FormMain>().Show();
    }

 

    private void AddCustomerBtn_Click(object sender, EventArgs e)
    {
       
        Close(); //closes this form
        FormFactory.Get<FormAddCustomers>().Show();
    }

    private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
    {
        //loops through the customer list and once the index of the customer list mathches the row where a button was clicked that customers name is then stored
        int i = 0;
        foreach (Customer elem in _customerService.Customers.List)
        {
            if (i == e.RowIndex)
            {
                customerName = elem.Name;
                customerIndex = i;
                cCustomer = elem;
            }
            i++;
        }
        
        Close(); //closes this form
        FormFactory.Get<FormOrder>().Show();

       
        
            
    
}

    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        
    }

    private void SearchBtn_Click(object sender, EventArgs e)
    {
        Customer getCust = _customerService.Customers[Regex.Replace(textBox1.Text, @"(\d{3})(\d{3})(\d{4})", "$1-$2-$3")];
        if (getCust != null)
        {
            foreach(Customer elem in _customerService.Customers.List)
                if(elem.Phone == Regex.Replace(textBox1.Text, @"(\d{3})(\d{3})(\d{4})", "$1-$2-$3"))
                {
                    cCustomer = elem;
                    customerName = elem.Name;
                    Close(); //closes this form
                    FormFactory.Get<FormOrder>().Show();
                }
              
            
        }
       
    }
}




