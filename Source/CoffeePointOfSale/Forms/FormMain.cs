using CoffeePointOfSale.Configuration;
using CoffeePointOfSale.Forms.Base;
using CoffeePointOfSale.Services.FormFactory;

namespace CoffeePointOfSale.Forms;

public partial class FormMain : FormBase
{
    public static Boolean isCustomer = false;
    public FormMain(IAppSettings appSettings) : base(appSettings)
    {
        InitializeComponent();
        isCustomer = false;
    }

    private void OnClickBtnManagement(object sender, EventArgs e)
    {
        Hide();
        FormFactory.Get<FormManagement>().ShowDialog();
    }

    private void OnClickBtnOrder(object sender, EventArgs e)
    {
        isCustomer = true;
        Hide();
        FormFactory.Get<FormOrder>().ShowDialog();
    }

    private void label1_Click(object sender, EventArgs e)
    {

    }

    private void button1_Click(object sender, EventArgs e)
    {
        Hide();
        FormFactory.Get<FormCustomerList>().ShowDialog();
    }
}