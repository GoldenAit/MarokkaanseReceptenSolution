# Marokkaanse Recepten App (WPF .NET 9)

## Beschrijving
Dit project is een desktop WPF-applicatie ontwikkeld in .NET 9.
De applicatie laat gebruikers toe om Marokkaanse recepten te beheren,
inclusief categorieën, recepten en ingrediënten.

De applicatie maakt gebruik van Entity Framework Core voor databanktoegang
en Identity Framework voor gebruikersbeheer en rollen.

---

## Functionaliteiten
- Registreren, inloggen en uitloggen
- Rollen: Admin en User
- Admin kan:
  - gebruikers bekijken
  - gebruikers blokkeren / deblokkeren
  - rollen wijzigen
- CRUD-functionaliteit via popup windows:
  - Categorie
  - Recept (met categorie selectie via ComboBox)
  - Ingrediënt (met recept selectie via ComboBox)
- Soft delete op alle modellen (IsDeleted)

---

## Gebruikte technologieën en libraries
- .NET 9
- WPF (XAML en C#)
- Entity Framework Core
- ASP.NET Identity
- SQL Server (LocalDB)

De gebruikte libraries volgen hun respectievelijke open-source licenties.

---

## AI-gebruik
Voor bepaalde onderdelen van deze applicatie werd AI-ondersteuning gebruikt,
onder andere bij:
- de structuur van WPF windows
- CRUD-logica
- Identity- en adminfunctionaliteiten

Alle code werd door de student zelf geïntegreerd, getest en begrepen,
conform de CopyWrite-richtlijnen van EHB.
