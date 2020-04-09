# ContactBook.API

Design and build either a 


	
REST APIs for a Contact Book (OR)
	A Console Library for a Contact Book 



Note : When “API” is mentioned below , it refers to either a REST API (OR) your library API based on what you have chosen


# Contacts

The API should support basic operations such as Create, Read, Update and Delete a contact. Each contact at the minimum should have a first name, last name and, of course a phone number!


	
The API should not accept duplicate contacts.
	The API should provide a search functionality and support pagination.
	


# Contact Groups

In addition, to contacts. The Contact Book API should also provide support for creating and managing Contact Groups. 


	
A contact group can contain zero or more contacts.
	A contact group can contain other contact groups.
	A contact group can contain a mix of contacts and contact groups.


The API should support basic operations such as Create, Read, Update, and Delete for a Contact Group. The API should also support managing the Contact Group, like adding a Contact / Contact Group to the Contact Group, deleting a Contact / Contact Group from a Contact Group, search for a Contact / Contact Group in a Contact Group, etc. The Contact Group at the minimum should contain a name.


	
The API should not accept duplicate contact groups. 
	The API should not accept – an add operation when a user is already a member of the contact group.
	The API should provide a search functionality and support pagination.

deduplication on name or phone number