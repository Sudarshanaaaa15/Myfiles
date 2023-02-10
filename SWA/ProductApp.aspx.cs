using ProductLib.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleWebApp
{
    public partial class ProductApp : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var component = ProductFactory.GetComponent();
                lstProducts.DataSource = component.GetAllProducts();
                lstProducts.DataTextField = "ProductName";
                lstProducts.DataValueField = "ProductId";
                lstProducts.DataBind();
            }


        }
        protected void lstProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            //txtId.Enabled = false;
            //var id = int.Parse(lstProducts.SelectedValue);
            //var selected = ProductFactory.GetComponent();
            //var getAll = selected.GetAllProducts();
            //foreach (var item in getAll)
            //{
            //    txtId.Text = item.ProductId.ToString();
            //    txtName.Text = item.ProductName;
            //    txtPrice.Text = item.ProductPrice.ToString();
            //    imgPic.ImageUrl = item.ProductIamge.ToString();
            //}
            var component = ProductFactory.GetComponent();
            var pId = int.Parse(lstProducts.SelectedItem.Value);
            var selectedProduct = component.GetAllProducts().Find((p) => p.ProductId == pId);
            populateData(selectedProduct);

            //txtId.Text = getAll.ProductId.ToString();
            //txtName.Text = getAll.ProductName;
            //txtPrice.Text = getAll.Price.ToString();
            //imgPic.ImageUrl = getAll.Image;
        }

        private void populateData(Product product)
        {
            txtId.Text = product.ProductId.ToString();
            txtName.Text = product.ProductName;
            txtPrice.Text = product.ProductPrice.ToString();
            imgPic.ImageUrl = product.ProductIamge;
            dpQuantity.Text = product.Quantity.ToString();
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            var component = ProductFactory.GetComponent();
            var product = new Product
            {
                ProductIamge = uploadFile(),
                ProductPrice = int.Parse(txtPrice.Text),
                ProductId = int.Parse(txtId.Text),
                ProductName = txtName.Text,
                Quantity = int.Parse(dpQuantity.Text)
            };
            component.UpdateProduct(product);
            Response.Redirect("ProductApp.aspx");

        }

        private string uploadFile()
        {
            string imgName = string.Empty;
            string imgPath = string.Empty;
            if (fileUploader.PostedFile.FileName != String.Empty)
            {
                //get the file name of the posted image           
                imgName = fileUploader.PostedFile.FileName;
                //sets the image path           
                imgPath = @".\Images\" + imgName;
                //then save it to the Folder  
                fileUploader.SaveAs(Server.MapPath(imgPath));
            }
            return imgPath;

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            var msg = "Product deleted Successfully";
            var alert = $"alert({msg})";
            var component = ProductFactory.GetComponent();
            component.DeleteProduct(int.Parse(txtId.Text));
            Page.ClientScript.RegisterClientScriptBlock(typeof(ProductApp), "Alert", alert, true);
            Response.Redirect("ProductApp.aspx");

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            var imgPath = uploadFile();

            var product = new Product
            {
                ProductIamge = imgPath,
                ProductPrice = int.Parse(txtPrice.Text),
                ProductName = txtName.Text,
                Quantity = int.Parse(dpQuantity.Text)
            };
            var component = ProductFactory.GetComponent();
            component.AddProduct(product);
            Response.Redirect("ProductApp.aspx");

        }
    }
}