# 📚 DesignPatterns

Bu repo, .NET ortamında farklı tasarım desenlerini (Design Patterns) incelemek ve örneklemek amacıyla geliştirilmiştir. 
Her desen için ayrı bir proje klasörü, 
örnek kod ve ilgili konseptin uygulaması bulunmaktadır. 
Aşağıda bulunan alanlarda, İlgili patternler ile ilgili örnekler ve kaynaklar bulunmaktadır.

---

## 🛠️ Kullanılan Teknolojiler

 -C# / .NET (özellikle Console uygulamaları ya da basit .NET projeleri)

 -SOLID prensipleri

 -Tasarım desenleri (Creational, Structural, Behavioral vb.)

 -Katmanlı mimari (desen bazlı uygulamalar)

 -Basit arayüz + sınıf yapılandırmaları ile soyutlama, bağımlılık yönetimi

---

🎯 Amaç ve Faydaları
---
Yazılım mimarisinde tasarım desenlerinin ne işe yaradığını öğrenmek
Her desenin güçlü ve zayıf yönlerini kavramak
Kod okunabilirliğini, sürdürülebilirliğini ve yeniden kullanılabilirliğini arttırmak
Bağımlılıkları azaltmak, kod tekrarını düşürmek
Soyutlama (abstraction), soyut sınıflar ve ara yüz (interface) kullanımı hakkında pratik kazanmak
---


## 📁 Proje Yapısı
---
```
DesignPatterns/
├── CQRSDesignPattern/                    # CQRS örneği
│   └── DesignPattern.CQRS/
├── ChainOfResponsibilityDesignPattern/    # Chain of Responsibility deseni
│   └── DesignPattern.ChainOfResponsibility/
├── CompositeDesignPattern/                # Composite deseni
│   └── DesignPattern.Composite/
├── DecoratorDesignPattern/                # Decorator deseni
│   └── DesignPattern.Decorator/
├── FacadeDesingPattern/                   # Facade deseni
│   └── DesignPattern.Facade/
├── IteratorDesingPattern/                 # Iterator deseni
│   └── DesignPattern.Iterator/
├── MediatorDesignPattern/                 # Mediator deseni
│   └── DesignPattern.Mediator/
├── ObserverDesignPattern/                 # Observer deseni
│   └── DesignPattern.Observer/
├── RepositoryDesignPattern/               # Repository deseni
│   └── (İlgili projeler)
├── TemplateMethodDesignPattern/           # Template Method deseni
│   └── DesignPattern.TemplateMethod/
├── UnitOfWorkDesignPattern/               # Unit of Work deseni
│   └── DesignPattern.UnitOfWork/
├── DesignPatterns.sln                     # Solution dosyası
├── .gitignore
└── .gitattributes
```
---


## 📸 **Proje Görselleri** &  📄 **Pattern Örneklemleri**
---


## 🔗 Chain of Responsibility
<br/>
Diğer Adlarıyla: CoR, Chain of Command
<br/>



---
## 🎯 Amaç (Intent)

Chain of Responsibility, bir isteği (request) bir dizi işleyici (handler) boyunca iletmenize izin veren davranışsal (behavioral) tasarım desenidir.
Her işleyici, kendisine gelen isteği ya işler ya da zincirdeki bir sonraki işleyiciye iletir.
---
<br/>

---

## ❓ Problem

Bir çevrim içi sipariş sistemi üzerinde çalıştığınızı düşünün:
➵Yalnızca doğrulanmış kullanıcıların sipariş oluşturabilmesini istiyorsunuz.
➵Yönetici yetkisine sahip kullanıcıların ise tüm siparişlere erişim hakkı olmalı.
➵Bu kontrollerin sıralı bir şekilde yapılması gerektiğini fark ettiniz.
➵İlk olarak, sistem kullanıcıyı doğrulamalı. Eğer kimlik doğrulama başarısız olursa diğer adımları yapmaya gerek yoktur.
➵Daha sonra verilerin güvenliği için girdi temizliği (validation/sanitization) yapılmalı.
➵Brute-force saldırılarını engellemek için aynı IP’den gelen tekrar eden hatalı girişler filtrelenmeli.
➵Performans için, önbellek kontrolü (cache) yapılmalı ve uygun yanıt varsa doğrudan dönülmeli.
<br/>

##  Eksiklikler
👉 Ancak her yeni kontrol eklendiğinde kod karmaşıklaştı, bakımın zorlaşması  ve tekrar kullanılabilirliği azaltır.
---


<br/>


---
## 💡 Çözüm

Chain of Responsibility, bu tür kontrolleri bağımsız nesnelere (handler) ayırmayı önerir.
➵Her kontrol, yalnızca tek bir sorumluluğa sahip ayrı bir sınıfta bulunur.
➵Bu sınıflar ortak bir arayüzü uygular (örneğin Handle(request) metodu).
➵İşleyiciler zincir şeklinde bağlanır.
➵Her işleyici, isteği işler ve zincirdeki bir sonraki işleyiciye aktarıp aktarmamaya kendisi karar verir.
<br/>
##  Artılar
👉 Böylece kontroller bağımsız, modüler, yeniden kullanılabilir ve dinamik olarak zincirlenebilir hale gelir.
---

<br/>

---

##  🌍 Gerçek Dünya Örneği

Bir donanım kurulumunda sorun yaşadınız ve teknik destek hattını aradınız:

1.Önce otomatik telesekreter yanıt verir (genel çözümler).
2.Sonra müşteri temsilcisine bağlanırsınız (temel yardım).
3.Sorun hâlâ çözülmezse çağrı mühendise iletilir.
4.Sonunda doğru kişiye ulaşıp çözümü elde edersiniz.
<br/>
👉 Burada çağrı, çözülene kadar bir zincir boyunca aktarılır.
---
<br/>

---

##  🏗 Yapı (Structure)

<b>Handler (İşleyici Arayüzü):<b/>
Tüm işleyicilerin uygulaması gereken ortak arayüz. Genelde Handle(request) metodu içerir.

<b>Base Handler (Temel İşleyici):<b/>
Sonraki işleyiciye geçişi yönetmek için kullanılabilen ortak sınıf.

<b>Concrete Handlers (Somut İşleyiciler):<b/>
Gerçek kontrol adımlarını içerir. İsteği işler ve isterse zincire devam ettirir.

<b>Client (İstemci):<b/>
Zinciri oluşturur ve isteği ilk işleyiciye gönderir.

---

##  🏗 Özet

🍃İstekler zincir boyunca aktarılır.
🍃Her işleyici isteği işleyebilir ya da bir sonrakine devredebilir.
🍃Yeni kontroller kolayca eklenip çıkarılabilir.
🍃Kod bakımı ve yeniden kullanılabilirliği artar.

---
<br/>
<img width="1111" height="418" alt="image" src="https://github.com/user-attachments/assets/06c55aaf-fe70-4a61-b440-532629c680be" />
<br/>




## ⚡ CQRS (Command Query Responsibility Segregation)
<br/>
Diğer Adlarıyla: Command Query Separation
<br/>


---
## 🎯 Amaç (Intent)


CQRS, veri okuma (Query) ve yazma (Command) işlemlerini ayrı modeller üzerinden ele alan bir tasarım desenidir.
Bu desen ile:
Veri okuma operasyonları hızlı ve optimize şekilde yapılabilir.
Veri yazma işlemleri ise ayrı bir akışta yönetilir.

👉 Temel amaç, okuma ve yazma operasyonlarının sorumluluklarını ayırarak daha ölçeklenebilir, anlaşılır ve yönetilebilir bir mimari kurmaktır.
---
<br/>

---

## ❓ Problem

Geleneksel uygulamalarda aynı model hem okuma hem de yazma işlemlerini karşılar.
Örneğin bir sipariş sistemi düşünelim:
➵Kullanıcı sipariş oluşturur (yazma).
➵Sipariş listesi görüntülenir (okuma).
<b>Zamanla sistem büyüdükçe:<b/>
➵Okuma işlemleri çok sık yapılır.
➵Yazma işlemleri daha karmaşık hale gelir (transaction, business rules).
➵Tek model üzerinde bu iki sorumluluğun birleşmesi, kodun karmaşık, zor test edilebilir ve bakımı maliyetli olmasına yol açar.

<br/>


---


<br/>


---
## 💡 Çözüm ➵

CQRS, tek model yerine:
<b>Command Model (Yazma):<b/>
➵Veritabanına veri ekleme, güncelleme, silme gibi değişiklik yapan işlemler.
➵“Komut” mantığıyla çalışır.
➵Genelde DTO veya ayrı Command nesneleri ile temsil edilir.
<b>Query Model (Okuma):<b/>
➵Sadece veri okuma, raporlama, listeleme işlemleri.
➵Performans için özelleştirilmiş olabilir (örneğin farklı DTO’lar, View modeller).


<br/>
##  Artılar
👉 Bu ayrım sayesinde okuma ve yazma operasyonları bağımsız ölçeklenebilir ve farklı optimizasyonlara izin verir.
---

<br/>

---

##  🌍 Gerçek Dünya Örneği

Bir restoran mutfağı düşünün:

a.Sipariş vermek (Command):
Garsona sipariş söylersiniz. Garson siparişi mutfağa iletir. (Yazma işlemi).

b.Siparişin durumunu öğrenmek (Query):
Garsona “yemek hazır mı?” diye sorabilirsiniz. Garson mutfağa bakar ve size bilgi verir. (Okuma işlemi).


<br/>
👉 Aynı garson hem siparişi alır (Command) hem de bilgi verir (Query). Ama mutfak içindeki süreçler ayrı sorumluluklarla yönetilir.
---
<br/>

---

##  🏗 Yapı (Structure)

<b>Command:<b/>
Veri üzerinde değişiklik yapan istekler (AddOrder, UpdateProduct, DeleteCustomer vb.).

<b>Query:<b/>
Veri okuma işlemleri (GetOrders, GetProductById, ListCustomers vb.).

<b>Handler (İşleyici):<b/>
Command veya Query nesnesini işleyen sınıf.

<b/>Mediator (Opsiyonel):<b/>
Command/Query isteklerini ilgili handler’a yönlendiren bileşen.

<b>Data Source:<b/>
Command ve Query için farklı olabilir (ör. Command için yazma odaklı veritabanı, Query için okuma replikası).

---


##  🏗 Özet


🍃Command = Yazma, Query = Okuma.
🍃Tek model yerine, iki ayrı model kullanılır.
🍃Kod daha temiz, test edilebilir ve ölçeklenebilir olur.
🍃Büyük sistemlerde (özellikle Microservice mimarisi ve Event Sourcing) çok tercih edilen bir yaklaşımdır.

---
<br/>
<img width="1102" height="416" alt="image" src="https://github.com/user-attachments/assets/6a56bc48-39a4-4e56-a6e3-3b0b75ec12ad" />
<br/>
<img width="1110" height="414" alt="image" src="https://github.com/user-attachments/assets/26a44787-3ac3-4422-8cfc-98a0d0e4372b" />
<br/>


MediaTR-Mediator Design Pattern
<img width="1081" height="401" alt="image" src="https://github.com/user-attachments/assets/efc56b0b-daf1-4927-9247-be2b48221a52" />
<br/>


Template Method Design Pattern
<img width="1086" height="413" alt="image" src="https://github.com/user-attachments/assets/dd2e2bb2-3050-4865-bc3e-e3ba83ec7079" />
<br/>


Observer Design Pattern
<img width="1101" height="406" alt="image" src="https://github.com/user-attachments/assets/4c404ad7-b2dd-4f1c-9071-2fa3217c5d8b" />
<br/>


Repository  Design Pattern
<img width="1107" height="410" alt="image" src="https://github.com/user-attachments/assets/7f332f05-0fe5-4f1e-9892-565947e1b90f" />
<br/>


Unit Of Work Design Pattern
<img width="1103" height="403" alt="image" src="https://github.com/user-attachments/assets/1ba1d1fe-44c7-4907-9f63-70f6316af3d8" />
<br/>

Composite Design Pattenr
<img width="397" height="354" alt="image" src="https://github.com/user-attachments/assets/7ab61a80-3fa1-457e-b14e-e82b586be4e0" />
<br/>


Iterator Design Pattern
<img width="1002" height="453" alt="image" src="https://github.com/user-attachments/assets/b0736139-f4da-4498-9c10-b5bc1790c3f4" />
<br/>

Facade Design Pattern
<img width="1049" height="446" alt="image" src="https://github.com/user-attachments/assets/849b8699-6fdd-477c-a79c-3f33512c0e07" />
<br/>

Decorator Design Pattern
<img width="1111" height="78" alt="image" src="https://github.com/user-attachments/assets/0c00bb64-5400-4ae7-a4ed-f3266c097767" />
<br/>




---




## ⚙️ Kurulum Talimatları

### 1. Reponun Klonlanması
```bash
git clone https://github.com/bhmberkan/DesignPatterns.git

Visual Studio / VS Code gibi bir IDE açın.

DesignPatterns.sln dosyasını açın ve Restore işlemi yapın

İlgili desen projesini StartUp projesi olarak seçerek çalıştırın (örneğin ChainOfResponsibilityDesignPattern)

Kodları inceleyin — örnek kullanımları, çıktıları anlamaya çalışın
```


## 🤝 Katkı Sağla

Her türlü katkıya açığız!

1. Fork'la ⭐  
2. Yeni bir branch oluştur  
3. Değişikliklerini commit et  
4. Pull Request gönder  
5. Kodu birlikte büyütelim!

---



## 👨‍💻 Geliştirici Bilgisi

- **👤 Adı**: Berkan Burak Turgut  
- 💼 **LinkedIn**: [linkedin.com/in/berkanburakturgut](https://www.linkedin.com/in/berkan-turgut-2a277a232/)  
- 💻 **GitHub**: [github.com/bhmberkan](https://github.com/bhmberkan)  
- 📧 **E-posta**: berkanburakturgut@gmail.com  

---

## 📄 Lisans

