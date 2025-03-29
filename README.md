# Yonoma .NET SDK

## Introduction
Yonoma .NET SDK provides a simple way to interact with the Yonoma API for managing lists, tags, contacts, and email sending.

## Installation
```sh
dotnet add package Yonoma --version 1.1.2
```

## Table of Contents
- [Authentication](#authentication)
- [Setup](#setup)
- [Usage](#usage)
  - [Lists](#lists)
  - [Tags](#tags)
  - [Contacts](#contacts)
  - [Sending Emails](#sending-emails)
- [Error Handling](#error-handling)
- [License](#license)


## Authentication
To use the Yonoma API, initialize the client with your API key:

```csharp
var Yonoma = new Yonoma("YOUR-API-KEY");
```

## Usage
### Lists
#### Create a List
```csharp
var response = await Yonoma.Lists.Create('list_name':'New group');
Console.WriteLine(response);
```

#### Get a list of Lists
```csharp
var response = await Yonoma.Lists.Lists();
Console.WriteLine(response);
```

#### Retrieve a specific list
```csharp
var response = await Yonoma.Lists.Retrieve("list_id");
Console.WriteLine(response);
```

#### Update a List
```csharp
var response = await Yonoma.Lists.Update("list_id", {
    'list_name': 'Upadated list name'
});
Console.WriteLine(response);
```

#### Delete a List
```csharp
var response = await Yonoma.Lists.Delete("list_id");
Console.WriteLine(response);
```

---

### Tags
#### Create a Tag
```csharp
var response = await Yonoma.Tags.Create({'tag_name': 'New tag'});
Console.WriteLine(response);
```

#### Get a list of tags
```csharp
var response = await Yonoma.Tags.List();
Console.WriteLine(response);
```

#### Retrieve a specific tag
```csharp
var response = await Yonoma.Tags.Retrieve("tag_id");
Console.WriteLine(response);
```

#### Update a Tag
```csharp
var response = await Yonoma.Tags.Update("tag_id", {
    'tag_name': 'Updated Tag Name'
});
Console.WriteLine(response);
```

#### Delete a Tag
```csharp
var response = await Yonoma.Tags.Delete("tag_id");
Console.WriteLine(response);
```

---

### Contacts
#### Create a Contact
```csharp
var response = await Yonoma.Contacts.Create("list_id", {
    email: "email@example.com",
    status: "Subscribed" | "Unsubscribed",
    firstName: string, //optional
    lastName: string, //optional
    phone: string, //optional
    gender: string, //optional
    address: string, //optional
    city: string, //optional
    state: string, //optional
    country: string, //optional
    zipcode: string, //optional
});
Console.WriteLine(response);
```

#### Unsubscribe a Contact
```csharp
var response = await Yonoma.Contacts.Update("list_id", "contact_id", {
    'status': "Subscribed" | "Unsubscribed" 
});
Console.WriteLine(response);
```

#### Add Tag to a Contact
```csharp
var response = await Yonoma.Contacts.AddTag("contact_id", {
    'tag_id': 'Tag id'
});
Console.WriteLine(response);
```

#### Remove Tag from a Contact
```csharp
var response = await Yonoma.Contacts.RemoveTag("contact_id", {
    'tag_id': 'Tag id'
});
Console.WriteLine(response);
```

---

### Sending Emails
#### Send an Email
```csharp
var response = await Yonoma.Email.SendEmail({
   'from_email': 'updates@yonoma.io',
    'to_email': 'email@yourdomain.com',
    'subject':"Welcome to Yonoma - You're In!",
    'mail_template': "We're excited to welcome you to Yonoma! Your successful signup marks the beginning of what we hope will be an exceptional journey."
});
Console.WriteLine(response);
```

---

## Error Handling
Each API call returns a response object that contains success or error messages. Handle errors using:

```csharp
try
{
    var response = Yonoma.Lists.Create("Existing List");
    Console.WriteLine(response);
}
catch (Exception ex)
{
    Console.WriteLine("Error: " + ex.Message);
}
```

---

## License
This project is licensed under the MIT License. See `LICENSE` for details.

