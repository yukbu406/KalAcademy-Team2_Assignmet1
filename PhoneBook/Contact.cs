﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhoneBook
{
    /// <summary>
    /// This is the blueprint for an contact
    /// </summary>
    public class Contact
    {
        private const string TEXT_FILE_NAME = "ContactTextFile.txt";
        /// <summary>
        /// Holds the name of the contact
        /// </summary>
        /// 
        public string FirstName { get; set; }

        public string LastName { get; set; }

        //public int PhoneNumber { get; set; }

        public string Email { get; set; }
  
        public string Group { get; set; }

        public string Work { get; set; }

        public async static Task<ICollection<Contact>> GetContacts()
        {
            var contacts = new List<Contact>();
            var fileContent = await FileHelper.ReadTextFileAsync(TEXT_FILE_NAME);
            var lines = fileContent.Split(new char[] { '\r', '\n' });
            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line))
                    continue;
                var lineParts = line.Split(',');
                var contact = new Contact
                {
                    FirstName = lineParts[0],
                    LastName = lineParts[1],
                    //PhoneNumber = lineParts[2],
                    Email = lineParts[3],               
                    Group = lineParts[4],
                    Work = lineParts[5]
                };
                contacts.Add(contact);
            }
            return contacts;
        }

        /// <summary>
        /// Write contact to file
        /// </summary>
        /// <param name="contact">The contact object to write</param>
        public static void WriteContact(Contact contact)
        {
            var contactData = $"{contact.Email},{contact.Group}";
            FileHelper.WriteTextFileAsync(TEXT_FILE_NAME, contactData);

        }
    }
}