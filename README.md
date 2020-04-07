# ContactBook.API

Here the most chellening functionality to achieve is contact group class , it has a one to many relationship with Contacts 
and one self join.

1 to many relationship we can acheive with storing the contact group ID in contacts entity.
For Self join ?

I think we should store just the ContactGroupID and ConactGroupName in Contact group object. If we need what all contacts are there
in a particular group we can create a lamda query.-- This will resolve( A contact group can contain zero or more contacts.)

then what about mixed contact group  and contacts?
for this we can add other contact group info like OtherContactGroupID and otherContactGroupName. In case a contact group just contains contacts then in that case this field can be null

What will happen in case a contact belongs to one contact group and then that contact group is added to another contact group?
