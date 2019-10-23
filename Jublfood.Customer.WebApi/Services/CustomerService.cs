using Jublfood.POSCustomer.WebApi.Entities;
using Jublfood.POSCustomer.WebApi.Models;
using Jublfood.POSCustomer.WebApi.Repositories;
using JublFood.POSCustomer.WebApi;
using System.Collections.Generic;

namespace Jublfood.POSCustomer.WebApi.Services
{
    public class CustomerService : ICustomerService
    {
        private ICustomerRepository _customerRepo;

        public CustomerService(ICustomerRepository customerRepo)
        {
            _customerRepo = customerRepo;
        }

        public GetCustomerByPhoneNumberResponse GetCustomerByPhoneNumber(GetCustomerByPhoneNumberRequest customerRequest)
        {
            GetCustomerByPhoneNumberResponse customerResponse = new GetCustomerByPhoneNumberResponse();

            List<Customer> customers = _customerRepo.GetCustomerByPhoneNumber(customerRequest.LocationCode, customerRequest.PhoneNumber, customerRequest.PhoneNumberExt);

            if (customers != null && customers.Count > 0)
            {
                customerResponse.Result = new Result();
                customerResponse.Result.ResponseStatus = CustomMessage.SuccessMessage;
                customerResponse.Result.ResponseStatusCode = CustomMessage.SuccessCode;

                foreach (var customer in customers)
                {
                    GetCustomerByPhoneNumberResult customerDetailModel = new GetCustomerByPhoneNumberResult();
                    customerDetailModel.Accept_Cash = customer.Accept_Cash;
                    customerDetailModel.Accept_Charge_Account = customer.Accept_Charge_Account;
                    customerDetailModel.Accept_Checks = customer.Accept_Checks;
                    customerDetailModel.Accept_Credit_Cards= customer.Accept_Credit_Cards;
                    customerDetailModel.Accept_Gift_Cards = customer.Accept_Gift_Cards;
                    customerDetailModel.Added = customer.Added;
                    customerDetailModel.Added_By = customer.Added_By;
                    customerDetailModel.Address_Line_2 = customer.Address_Line_2;
                    customerDetailModel.Address_Line_3 = customer.Address_Line_3;
                    customerDetailModel.Address_Line_4 = customer.Address_Line_4;
                    customerDetailModel.Address_Type = customer.Address_Type;
                    customerDetailModel.anniversary_date = customer.anniversary_date;
                    customerDetailModel.Customer_GSTIN = customer.Customer_GSTIN;
                    customerDetailModel.Cart = customer.Cart;
                    customerDetailModel.Company_Name = customer.Company_Name;
                    //customerDetailModel.Credit_Limit = customer.Credit_Limit;
                    //customerDetailModel.Cross_Street_Code = customer.Cross_Street_Code;
                    customerDetailModel.Customer_Code = customer.Customer_Code;
                    customerDetailModel.date_of_birth = customer.date_of_birth;
                    customerDetailModel.Delivery_Point_Code = customer.Delivery_Point_Code;
                    //customerDetailModel.Finance_Charge_Rate = customer.Finance_Charge_Rate;
                    customerDetailModel.First_Order_Date = customer.First_Order_Date;
                    customerDetailModel.Last_Order_Date = customer.Last_Order_Date;

                    customerDetailModel.Location_Code = customer.Location_Code;
                    customerDetailModel.Mailing_Address = customer.Mailing_Address;
                    customerDetailModel.Name = customer.Name;
                    //customerDetailModel.Payment_Terms = customer.Payment_Terms;
                    customerDetailModel.Phone_Ext = customer.Phone_Ext;
                    customerDetailModel.Phone_Number = customer.Phone_Number;


                    customerDetailModel.Plus4 = customer.Plus4 ;
                    customerDetailModel.Postal_Code = customer.Postal_Code;
                    //customerDetailModel.Set_Discount = customer.Set_Discount;
                    //customerDetailModel.Street_Code = customer.Street_Code;
                    customerDetailModel.Phone_Ext = customer.Phone_Ext;
                    customerDetailModel.Street_Number = customer.Street_Number;

                    customerResponse.Result.CustomerDetail = new GetCustomerByPhoneNumberResult();
                    customerResponse.Result.CustomerDetail = customerDetailModel;
                }

            }

            return customerResponse;

        }

        public SaveCustomerResponse SaveCustomer(SaveCustomerRequest saveCustomerRequestModel)
        {
            SaveCustomerResponse saveCustomerResponseModel = new SaveCustomerResponse();
            Customer customer = new Customer();

            customer.Added_By = saveCustomerRequestModel.Added_By;
            customer.Address_Line_2 = saveCustomerRequestModel.Address_Line_2;
            customer.Address_Line_3 = saveCustomerRequestModel.Address_Line_3;
            customer.Address_Line_4 = saveCustomerRequestModel.Address_Line_4;
            customer.Address_Type = saveCustomerRequestModel.Address_Type;
            customer.anniversary_date = saveCustomerRequestModel.anniversary_date;
            customer.Company_Name = saveCustomerRequestModel.Company_Name;

            //customer. = saveCustomerRequestModel.Cross_Street_Code;

            customer.date_of_birth = saveCustomerRequestModel.date_of_birth;
            //customer. = saveCustomerRequestModel.Finance_Charge_Rate;
            customer.First_Order_Date = saveCustomerRequestModel.First_Order_Date;
            customer.Last_Order_Date = saveCustomerRequestModel.Last_Order_Date;
            customer.Location_Code = saveCustomerRequestModel.Location_Code;
            customer.Name = saveCustomerRequestModel.Name;
            customer.Phone_Ext = saveCustomerRequestModel.Phone_Ext;
            customer.Phone_Number = saveCustomerRequestModel.Phone_Number;
            customer.Postal_Code = saveCustomerRequestModel.Postal_Code;
            //customer.stre = saveCustomerRequestModel.Street_Code;
            customer.Street_Number = saveCustomerRequestModel.Street_Number;
            customer.Suite = saveCustomerRequestModel.Suite;
            customer.Tax_Exempt1 = saveCustomerRequestModel.Tax_Exempt1;
            customer.Tax_Exempt2 = saveCustomerRequestModel.Tax_Exempt2;
            customer.Tax_Exempt3 = saveCustomerRequestModel.Tax_Exempt3;
            customer.Tax_Exempt4 = saveCustomerRequestModel.Tax_Exempt4;
            customer.Tax_ID1 = saveCustomerRequestModel.Tax_ID1;
            customer.Tax_ID2 = saveCustomerRequestModel.Tax_ID2;
            customer.Tax_ID3 = saveCustomerRequestModel.Tax_ID3;
            customer.Tax_ID4 = saveCustomerRequestModel.Tax_ID4;
            customer.Customer_Code = saveCustomerRequestModel.Customer_Code;

            int returnId = _customerRepo.SaveCustomer(customer);

            if (returnId > 0)
            {
                saveCustomerResponseModel.Result = new SaveCustomerResult();
                saveCustomerResponseModel.Result.ResponseStatus = CustomMessage.SuccessMessage;
                saveCustomerResponseModel.Result.ResponseStatusCode = CustomMessage.SuccessCode;
            }
            else
            {
                saveCustomerResponseModel.Result = new SaveCustomerResult();
                saveCustomerResponseModel.Result.ResponseStatus = CustomMessage.FailureMessage;
                saveCustomerResponseModel.Result.ResponseStatusCode = CustomMessage.FailureMessage;
            }

            return saveCustomerResponseModel;
        }

    }
}
