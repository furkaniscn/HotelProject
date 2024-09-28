# HotelProject

HotelProject, otel rezervasyonları ve kullanıcı yönetimi gibi otel işlemlerini yönetmek için geliştirilmiş bir web uygulamasıdır. Projede JWT tabanlı kimlik doğrulama, API kullanımları, MVC mimarisi gibi modern yazılım teknolojileri kullanılmıştır.

## Özellikler

- **Kullanıcı Kimlik Doğrulama (JWT)**: Güvenli giriş işlemleri ve kullanıcı yönetimi için JSON Web Token (JWT) tabanlı kimlik doğrulama.
- **RapidAPI Entegrasyonu**: Farklı otel bilgileri ve kullanıcı verilerini almak için RapidAPI kullanımı.
- **MVC Mimari Yapısı**: Model-View-Controller (MVC) yapısıyla projenin modüler ve düzenli bir şekilde geliştirilmesi.
- **API Kullanımı**: Restful API'ler ile veri alışverişi ve dış kaynaklardan veri çekme işlemleri.
- **Otel Yönetimi**: Otel bilgileri, rezervasyonlar ve oda detaylarını yönetme.
- **Rol Yönetimi**: Farklı kullanıcı rolleri ve izinler, kullanıcıların otel yönetimindeki farklı işlemlerini kontrol eder.
- **Kullanıcı Yönetimi**: Kullanıcıların kaydı, girişi ve işlemleri. Ayrıca kullanıcı rollerinin atanması.

## Kullanılan Teknolojiler

- **ASP.NET Core MVC**: Projenin temel yapısı, modern web uygulamaları geliştirmek için ASP.NET Core MVC ile inşa edilmiştir.
- **Entity Framework Core**: Veritabanı yönetimi ve veri erişimi için Entity Framework Core kullanıldı.
- **JSON Web Token (JWT)**: Kimlik doğrulama ve kullanıcı oturum yönetimi için JWT kullanıldı.
- **RapidAPI**: Otel bilgileri ve diğer veri kaynaklarına erişim için RapidAPI kullanıldı.
- **PostgreSQL / MSSQL**: Proje veritabanı yönetimi için PostgreSQL veya MSSQL kullanıldı.
- **Identity Framework**: Kullanıcı kayıt ve giriş işlemleri için Microsoft Identity Framework entegre edildi.
- **Bootstrap & CSS**: Kullanıcı arayüzü için modern ve duyarlı tasarımlar Bootstrap ve CSS ile oluşturuldu.

## Kurulum

Projeyi yerel ortamınızda çalıştırmak için aşağıdaki adımları izleyebilirsiniz:

1. Projeyi GitHub'dan klonlayın:
   ```bash
   git clone https://github.com/kullaniciadi/HotelProject.git
   
2. Gerekli bağımlılıkları yükleyin: 
    dotnet restore
    
3. Veritabanı ayarlarını güncelleyin ve veritabanını oluşturun:
    dotnet ef database update

4. Veritabanı ayarlarını güncelleyin ve veritabanını oluşturun:
    dotnet run

