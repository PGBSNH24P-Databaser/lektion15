---
author: Lektion 15
date: MMMM dd, YYYY
paging: "%d / %d"
---

# Lektion 15

Hej och välkommen!

## Agenda

1. Frågor och repetition
2. Introduktion till säkerhet för databaser
3. Quiz frågor
4. Grupparbete med handledning

---

# Introduktion till säkerhet

- Användare och tillgångar
- Hashing av lösenord
- Spara backups av data
- Connection strings
- Kryptera kommunikation
- SQL injections

---

# Hashing

Omvandla text till en oläsbar variant.

```csharp
using System.Security.Cryptography;
using System.Text;

string password = "secure-password";

StringBuilder sb = new StringBuilder();
using (HashAlgorithm algorithm = SHA256.Create())
{
  byte[] hash = algorithm.ComputeHash(Encoding.UTF8.GetBytes(password));
  foreach (byte b in hash)
      sb.Append(b.ToString("X2"));

}

string hashedPassword = sb.ToString();
```

# Hashing algoritmer

- SHA
- HMAC
- MD
- BCrypt (bra, kräver lib)
- Argon2 (bäst, kräver lib)

---

# Principen bakom hashing

Du får numret 15 och skall ange de 3 nummer som tillsammans adderar upp till det.

- `5 + 5 + 5`
- `7 + 3 + 5`
- `5 + 9 + 1`
- `3 + 3 + 10`
- med flera

---

# Hashing + salting

Förhindra användning av rainbow tables.

```csharp
using System.Security.Cryptography;
using System.Text;

string password = "secure-password";

// Generate salt
byte[] salt = RandomNumberGenerator.GetBytes(16);

byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
byte[] fullBytes = passwordBytes.Concat(salt).ToArray();

StringBuilder sb = new StringBuilder();
using (HashAlgorithm algorithm = SHA256.Create())
{
  byte[] hash = algorithm.ComputeHash(fullBytes);
  foreach (byte b in hash)
      sb.Append(b.ToString("X2"));
}

string hashedPassword = sb.ToString();
```

---

# Kryptering

- Fungerar likt hashing men data kan omvandlas tillbaka
- Hindrar hackers från att läsa kommunikation
- Fungerar ofta genom "nyckelpar" (public och private keys)

`postgresql://localhost/todo?sslmode=verify-full`

---

# PostgreSQL användare

```sql
CREATE ROLE username WITH LOGIN PASSWORD 'password';

GRANT SELECT, DELETE ON tablename TO username;
GRANT CONNECT ON tablename TO username;
GRANT CREATE DELETE ON tablename TO username;

REVOKE SELECT, DELETE ON tablename FROM username;

GRANT ALL PRIVILEGES ON tablename TO username;
```

---

# Connection strings

- Spara inte i kod
- Dela inte med andra
- Använd fil med .gitignore eller miljövariabel

---

# Quiz frågor

- Vad är `NpgsqlCommand.Parameters` till för?
- Vad innebär hashing?
- Vad är salting och varför används det?
- Vad innebär kryptering, och hur skiljer det sig från hashing?
- Ge ett exempel på en hashing algoritm
- Varför skall man ta backups?
- Varför är det viktigt att skapa användare med olika tillgångar?
