﻿using System;
using System.Net.Mail;

namespace ApprovalBot.Helpers
{
    public static class EmailHelper
    {
        public static bool IsValidSmtpAddress(string address)
        {
            try
            {
                new MailAddress(address);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public static string[] ConvertDelimitedAddressStringToArray(string addressString)
        {
            string[] addresses = addressString.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            foreach(string address in addresses)
            {
                if (!IsValidSmtpAddress(address))
                {
                    return null;
                }
            }

            return addresses;
        }
    }
}