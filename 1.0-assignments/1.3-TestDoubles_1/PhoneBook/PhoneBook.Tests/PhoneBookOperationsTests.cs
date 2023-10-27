using FluentAssertions;
using Newtonsoft.Json.Linq;
using PhoneBook.Tests.TestDoubles;
using System.Collections.Immutable;

namespace PhoneBook.Tests
{
    public class PhoneBookOperationsTests
    {
        [Fact]
        public void GivenNewPhoneBookOperationsInstanceWithInputUrl_WhenContactsGetterIsCalled_ThenGivesAllContactsWithoutError()
        {
            //Arrange
            string inputUrl = "phonebook.json"; 
            IPhoneBook phonebookSpy = new PhoneBookSpy(inputUrl);
            PhoneBookOperations sut = new PhoneBookOperations(phonebookSpy);

            //Act
            Action expectedContacts = () => { ImmutableList<Contact>? contacts = sut.Contacts; };

            //Assert
            expectedContacts.Should().NotThrow();
            sut.Contacts.Should().NotBeNull();

            //Cleanup
            if (File.Exists(inputUrl))
            {
                File.Delete(inputUrl);
            }
        }

        [Fact]
        public void GivenNewPhoneBookOperationsInstanceWithInputUrl_WhenFavoritesGetterIsCalled_ThenGivesAllFavoriteContactsWithoutError()
        {
            //Arrange
            string inputUrl = "phonebook.json";
            IPhoneBook phonebookSpy = new PhoneBookSpy(inputUrl);
            PhoneBookOperations sut = new PhoneBookOperations(phonebookSpy);

            //Act
            Action expectedContacts = () => { IEnumerable<Contact>? contacts = sut.Favorites; };

            //Assert
            expectedContacts.Should().NotThrow();
            sut.Favorites.Should().NotBeNull();

            //Cleanup
            if (File.Exists(inputUrl))
            {
                File.Delete(inputUrl);
            }
        }

        [Fact]
        public void GivenNewPhoneBookOperationsInstanceWithInputUrl_WhenAddContactIsCalled_ThenNewValidatedContactIsPresentInAllContacts()
        {
            //Arrange
            string expectedFirstName = "Luffy";
            string expectedLastName = "Monkey D.";
            string expectedPhoneNumber = "0491632155";


            string inputUrl = "phonebook.json";
            IPhoneBook phonebookSpy = new PhoneBookSpy(inputUrl);
            PhoneBookOperations sut = new PhoneBookOperations(phonebookSpy);

            //Act
            Action executeAddingContact = () => sut.AddContact(expectedFirstName, expectedLastName, expectedPhoneNumber);

            //Assert
            Func<Contact, bool> doesContactMatchExpected = (selectedContact) => (
            (selectedContact.FirstName == expectedFirstName) && 
            (selectedContact.LastName == expectedLastName) && 
            (selectedContact.PhoneNumber == expectedPhoneNumber));

            executeAddingContact.Should().NotThrow();
            sut.Contacts.Should().Contain(selectedItem => doesContactMatchExpected(selectedItem));
            
            //Cleanup
            if (File.Exists(inputUrl))
            {
                File.Delete(inputUrl);
            }
        }

        [Fact]
        public void GivenNewPhoneBookOperationsInstanceWithInputUrl_WhenAddContactIsCalledTwiceWithIdenticalPhoneNumber_ThenThrowsArgumentExceptionWithCorrectMessage()
        {
            //Arrange
            string expectedFirstName = "Luffy";
            string expectedLastName = "Monkey D.";
            string expectedPhoneNumber = "0491632155";

            string expectedErrorMessage = "Phonenumber already exists";

            string inputUrl = "phonebook.json";
            IPhoneBook phonebookSpy = new PhoneBookSpy(inputUrl);
            PhoneBookOperations sut = new PhoneBookOperations(phonebookSpy);

            //Act
            Action executeAddingContact = () => { sut.AddContact(expectedFirstName, expectedLastName, expectedPhoneNumber); sut.AddContact(expectedFirstName, expectedLastName, expectedPhoneNumber); };

            //Assert
            executeAddingContact.Should().ThrowExactly<ArgumentException>().Where(thrownException => thrownException.Message.Contains(expectedErrorMessage));

            //Cleanup
            if (File.Exists(inputUrl))
            {
                File.Delete(inputUrl);
            }
        }

        [Fact]
        public void GivenNewPhoneBookOperationsInstanceWithInputUrl_WhenAddContactIsCalledWithInvalidPhoneNumber_ThenThrowsArgumentExceptionWithCorrectMessage()
        {
            //Arrange
            string expectedFirstName = "Luffy";
            string expectedLastName = "Monkey D.";
            string expectedPhoneNumber = "invalid phone number";

            string expectedErrorMessage = "Invalid phoneNumber";

            string inputUrl = "phonebook.json";
            IPhoneBook phonebookSpy = new PhoneBookSpy(inputUrl);
            PhoneBookOperations sut = new PhoneBookOperations(phonebookSpy);

            //Act
            Action executeAddingContact = () => sut.AddContact(expectedFirstName, expectedLastName, expectedPhoneNumber);

            //Assert
            executeAddingContact.Should().ThrowExactly<ArgumentException>().Where(thrownException => thrownException.Message.Contains(expectedErrorMessage));

            //Cleanup
            if (File.Exists(inputUrl))
            {
                File.Delete(inputUrl);
            }
        }

        [Fact]
        public void GivenNewPhoneBookOperationsInstanceWithInputUrl_WhenAddContactIsCalledWithInvalidFirstName_ThenThrowsArgumentExceptionWithCorrectMessage()
        {
            //Arrange
            string expectedFirstName = "Lu";
            string expectedLastName = "Monkey D.";
            string expectedPhoneNumber = "0491632155";

            string expectedErrorMessage = "Invalid firstName";

            string inputUrl = "phonebook.json";
            IPhoneBook phonebookSpy = new PhoneBookSpy(inputUrl);
            PhoneBookOperations sut = new PhoneBookOperations(phonebookSpy);

            //Act
            Action executeAddingContact = () => sut.AddContact(expectedFirstName, expectedLastName, expectedPhoneNumber);

            //Assert
            executeAddingContact.Should().ThrowExactly<ArgumentException>().Where(thrownException => thrownException.Message.Contains(expectedErrorMessage));

            //Cleanup
            if (File.Exists(inputUrl))
            {
                File.Delete(inputUrl);
            }
        }

        [Fact]
        public void GivenNewPhoneBookOperationsInstanceWithInputUrl_WhenAddContactIsCalledWithInvalidLastName_ThenThrowsArgumentExceptionWithCorrectMessage()
        {
            //Arrange
            string expectedFirstName = "Luffy";
            string expectedLastName = "Mo";
            string expectedPhoneNumber = "0491632155";

            string expectedErrorMessage = "Invalid lastName";


            string inputUrl = "phonebook.json";
            IPhoneBook phonebookSpy = new PhoneBookSpy(inputUrl);
            PhoneBookOperations sut = new PhoneBookOperations(phonebookSpy);

            //Act
            Action executeAddingContact = () => sut.AddContact(expectedFirstName, expectedLastName, expectedPhoneNumber);

            //Assert
            executeAddingContact.Should().ThrowExactly<ArgumentException>().Where(thrownException => thrownException.Message.Contains(expectedErrorMessage));

            //Cleanup
            if (File.Exists(inputUrl))
            {
                File.Delete(inputUrl);
            }
        }

        [Fact]
        public void GivenNewPhoneBookOperationsInstanceWithInputUrl_WhenAddQuickDialIsCalledTwiceWithSameNumber_ThenThrowsArgumentExceptionWithCorrectMessage()
        {
            //Arrange
            string expectedFirstName = "Luffy";
            string expectedLastName = "Monkey D.";
            string expectedPhoneNumber1 = "0491632155";
            string expectedPhoneNumber2 = "0491632156";
            int expectedQuickDial = 1;

            string expectedErrorMessage = "Quickdial already taken";

            string inputUrl = "phonebook.json";
            IPhoneBook phonebookSpy = new PhoneBookSpy(inputUrl);
            PhoneBookOperations sut = new PhoneBookOperations(phonebookSpy);

            //Act
            Action executeAddingContact = () =>
            {
                sut.AddContact(expectedFirstName, expectedLastName, expectedPhoneNumber1);
                sut.AddContact(expectedFirstName, expectedLastName, expectedPhoneNumber2);
                sut.AddQuickDial(sut.Contacts[0], expectedQuickDial);
                sut.AddQuickDial(sut.Contacts[1], expectedQuickDial);
            };

            //Assert
            executeAddingContact.Should().ThrowExactly<ArgumentException>().Where(thrownException => thrownException.Message.Contains(expectedErrorMessage));

            //Cleanup
            if (File.Exists(inputUrl))
            {
                File.Delete(inputUrl);
            }
        }

        [Fact]
        public void GivenNewPhoneBookOperationsInstanceWithInputUrl_WhenRemoveContactIsCalledWithInitialisedContact_ThenContactsDoesNotContainInitialisedContact()
        {
            //Arrange
            string expectedFirstName = "Luffy";
            string expectedLastName = "Monkey D.";
            string expectedPhoneNumber = "0491632155";

            string inputUrl = "phonebook.json";
            IPhoneBook phonebookSpy = new PhoneBookSpy(inputUrl);
            PhoneBookOperations sut = new PhoneBookOperations(phonebookSpy);

            //Act
            Action executeAddingContact = () =>
            {
                sut.AddContact(expectedFirstName, expectedLastName, expectedPhoneNumber);
                sut.RemoveContact(sut.Contacts[0]);
            };

            //Assert
            Func<Contact, bool> doesContactMatchExpected = (selectedContact) => (
            (selectedContact.FirstName == expectedFirstName) &&
            (selectedContact.LastName == expectedLastName) &&
            (selectedContact.PhoneNumber == expectedPhoneNumber));

            executeAddingContact.Should().NotThrow();
            sut.Contacts.Should().NotContain(selectedItem => doesContactMatchExpected(selectedItem));

            //Cleanup
            if (File.Exists(inputUrl))
            {
                File.Delete(inputUrl);
            }
        }
    }
}
