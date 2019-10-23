using Jublfood.POSCustomer.WebApi.Entities;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Jublfood.POSCustomer.WebApi.Data
{
    public static class CustomerDataAccess
    {

        public static DataTable GetCustomerByPhoneNumber(string locationCode, string phoneNumber, string phoneExtension)
        {

            SqlParameter[] parameters =
            {
                new SqlParameter("@Location_Code",locationCode),
                new SqlParameter("@Phone_Number",phoneNumber),
                new SqlParameter("@Phone_Ext",phoneExtension)
            };

            return SQLHelper.SPExecuteDataTable(DALConstant.GetPOSCustomerLookUpTaxByCity, parameters.ToList());

        }

        public static int SaveCustomer(Customer customer)
        {            

            if(customer.Customer_Code == 0)
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@Location_Code",customer.Location_Code),
                    new SqlParameter("@Phone_Number",customer.Phone_Number),
                    new SqlParameter("@Phone_Ext",customer.Phone_Ext),
                    new SqlParameter("@Name",customer.Name),
                    new SqlParameter("@Street_Number",customer.Street_Number),

                    new SqlParameter("@Street_Code",1),
                    new SqlParameter("@Cross_Street_Code",1),
                    new SqlParameter("@Finance_Charge_Rate",2),

                    new SqlParameter("@Suite",customer.Suite),
                    new SqlParameter("@Address_Line_2",customer.Address_Line_2),
                    new SqlParameter("@Address_Line_3",customer.Address_Line_3),
                    new SqlParameter("@Address_Line_4",customer.Address_Line_4),
                    new SqlParameter("@Postal_Code",customer.Postal_Code),
                    new SqlParameter("@Added_By",customer.Added_By),
                    new SqlParameter("@Address_Type",customer.Address_Type),
                    new SqlParameter("@Tax_Exempt1",customer.Tax_Exempt1),
                    new SqlParameter("@Tax_Exempt2",customer.Tax_Exempt2),
                    new SqlParameter("@Tax_Exempt3",customer.Tax_Exempt3),
                    new SqlParameter("@Tax_Exempt4",customer.Tax_Exempt4),
                    new SqlParameter("@Tax_ID1",customer.Tax_ID1),
                    new SqlParameter("@Tax_ID2",customer.Tax_ID2),
                    new SqlParameter("@Tax_ID3",customer.Tax_ID3),
                    new SqlParameter("@Tax_ID4",customer.Tax_ID4),
                    new SqlParameter("@First_Order_Date",customer.First_Order_Date),
                    new SqlParameter("@Last_Order_Date",customer.Last_Order_Date),
                    new SqlParameter("@Company_Name",customer.Company_Name),
                    new SqlParameter("@date_of_birth",customer.date_of_birth),
                    new SqlParameter("@anniversary_date",customer.anniversary_date)
                };

                return SQLHelper.SPExecuteNonQuery(DALConstant.InsertCustomer, parameters.ToList());
            }
            else
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@Location_Code",customer.Location_Code),
                    new SqlParameter("@Phone_Number",customer.Phone_Number),
                    new SqlParameter("@Phone_Ext",customer.Phone_Ext),
                    new SqlParameter("@Name",customer.Name),
                    new SqlParameter("@Street_Number",customer.Street_Number),

                    new SqlParameter("@Street_Code",1),
                    new SqlParameter("@Cross_Street_Code",1),
                    new SqlParameter("@Finance_Charge_Rate",2),

                    new SqlParameter("@Suite",customer.Suite),
                    new SqlParameter("@Address_Line_2",customer.Address_Line_2),
                    new SqlParameter("@Address_Line_3",customer.Address_Line_3),
                    new SqlParameter("@Address_Line_4",customer.Address_Line_4),
                    new SqlParameter("@Postal_Code",customer.Postal_Code),
                    new SqlParameter("@Added_By",customer.Added_By),
                    new SqlParameter("@Address_Type",customer.Address_Type),
                    new SqlParameter("@Tax_Exempt1",customer.Tax_Exempt1),
                    new SqlParameter("@Tax_Exempt2",customer.Tax_Exempt2),
                    new SqlParameter("@Tax_Exempt3",customer.Tax_Exempt3),
                    new SqlParameter("@Tax_Exempt4",customer.Tax_Exempt4),
                    new SqlParameter("@Tax_ID1",customer.Tax_ID1),
                    new SqlParameter("@Tax_ID2",customer.Tax_ID2),
                    new SqlParameter("@Tax_ID3",customer.Tax_ID3),
                    new SqlParameter("@Tax_ID4",customer.Tax_ID4),
                    new SqlParameter("@Customer_Code",customer.Customer_Code),
                    new SqlParameter("@Last_Order_Date",customer.Last_Order_Date),
                    new SqlParameter("@Company_Name",customer.Company_Name),
                    new SqlParameter("@date_of_birth",customer.date_of_birth),
                    new SqlParameter("@anniversary_date",customer.anniversary_date)
                };

                return SQLHelper.SPExecuteNonQuery(DALConstant.UpdateCustomer, parameters.ToList());
            }

        }
    }
}
