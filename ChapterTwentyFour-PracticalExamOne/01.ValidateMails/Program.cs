using System;
using System.IO;
using System.Text.RegularExpressions;

namespace _01.ValidateMails
{
    class Program
    {
        const string InputFileName = "mails.txt";
        const string OutputFileName = "validMails.txt";
        const string UsernameRegex = @"^[a-zA-Z]+([_{1}]|[.{1}])+[a-zA-Z]+$";
        const string HostRegex = @"^[a-z]+$";
        const string DomainRegex = @"^[a-z]{2,4}$";

        static void Main(string[] args)
        {
            if (!File.Exists(InputFileName))
            {
                Console.WriteLine($"File {InputFileName} was not found.");
                return;
            }

            using (var reader = new StreamReader(InputFileName))
            {
                using (var writer = new StreamWriter(OutputFileName))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        bool isValid = ValidateMail(line);

                        if (isValid)
                        {
                            writer.WriteLine(line);
                        }
                    }
                }
            }
        }

        static bool ValidateMail(string text)
        {
            string mail = text.Split(' ')[2];

            if (!mail.Contains('@') || !mail.Contains('.'))
            {
                return false;
            }

            string[] firstSplit = mail.Split('@');
            string[] secondSplit = firstSplit[1].Split('.');

            if (secondSplit.Length + firstSplit.Length != 4)
            {
                return false;
            }

            string username = firstSplit[0];
            string host = secondSplit[0];
            string domain = secondSplit[1];
            
            if (!Regex.Match(username, UsernameRegex).Success)
            {
                return false;
            }
            if (!Regex.Match(host, HostRegex).Success)
            {
                return false;
            }
            if (!Regex.Match(domain, DomainRegex).Success)
            {
                return false;
            }

            return true;
        }
    }
}
