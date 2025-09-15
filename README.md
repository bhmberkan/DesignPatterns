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
<br/>
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

##  ✅ Özet

🍃İstekler zincir boyunca aktarılır. <br/>
🍃Her işleyici isteği işleyebilir ya da bir sonrakine devredebilir.<br/>
🍃Yeni kontroller kolayca eklenip çıkarılabilir.<br/>
🍃Kod bakımı ve yeniden kullanılabilirliği artar.<br/>

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
## 💡 Çözüm 

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
<br/>

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


##  ✅ Özet


🍃Command = Yazma, Query = Okuma. <br/>
🍃Tek model yerine, iki ayrı model kullanılır. <br/>
🍃Kod daha temiz, test edilebilir ve ölçeklenebilir olur. <br/>
🍃Büyük sistemlerde (özellikle Microservice mimarisi ve Event Sourcing) çok tercih edilen bir yaklaşımdır. <br/>

---
<br/>
<img width="1102" height="416" alt="image" src="https://github.com/user-attachments/assets/6a56bc48-39a4-4e56-a6e3-3b0b75ec12ad" />
<br/>
<img width="1110" height="414" alt="image" src="https://github.com/user-attachments/assets/26a44787-3ac3-4422-8cfc-98a0d0e4372b" />
<br/>

<br/>

## ⚡Mediator (Arabulucu) Tasarım Deseni
<br/>
Diğer Adları: Intermediary, Controller
<br/>


---
## 🎯 Amaç (Intent)

Mediator, davranışsal (behavioral) bir tasarım desenidir.
Amaç: Nesneler arasındaki karmaşık bağımlılıkları azaltmak, doğrudan iletişimi engelleyip, tüm etkileşimi yalnızca bir arabulucu (mediator) nesne üzerinden gerçekleştirmektir.

---
<br/>

---

## ❓ Problem


Bir kullanıcı arayüzü (UI) düşünelim. Örneğin: müşteri profili oluşturma formu. Bu formda; textbox, checkbox, buton gibi farklı bileşenler vardır.

➵"Köpeğim var" kutucuğunu işaretleyince köpek ismi için ek bir alan açılması gerekebilir.
➵"Kaydet" butonuna tıklayınca, formdaki tüm alanların doğrulanması gerekebilir.

Bu durumda:

➵Bileşenler birbirine doğrudan bağımlı hale gelir.
➵Checkbox sınıfı, textbox’ı bilmek zorunda kalır.
➵Buton, bütün form elemanlarını kontrol etmek zorunda kalır.

👉 Sonuç: Kod yeniden kullanılabilirliğini kaybeder. Bir bileşeni başka yerde tek başına kullanmak zorlaşır.


<br/>


---


<br/>


---
## 💡 Çözüm 

Mediator deseni, doğrudan iletişimi ortadan kaldırır.

➵Her bileşen, yalnızca Mediator ile konuşur.
➵Mediator, hangi bileşenin nasıl tepki vereceğini belirler.
➵Bileşenler arasında gevşek bağlılık (loose coupling) sağlanır.

Örneğin:

➵"Kaydet" butonu sadece “Mediator’a haber ver” görevini yapar.
➵Mediator, formdaki diğer alanların doğrulanması gerektiğine karar verir ve onları tetikler.

Bu sayede, bileşenlerin tek tek bağımlılığı ortadan kalkar.
---

<br/>

---

##  🌍 Gerçek Dünya Örneği

Hava Trafik Kontrol Kulesi ✈️

a.Pilotlar doğrudan birbirleriyle konuşmaz.
a.Her pilot sadece kontrol kulesi ile iletişim kurar.
a.Kule, hangi uçağın önce ineceğine karar verir.

👉 Eğer pilotlar doğrudan birbirleriyle konuşsaydı, havaalanında kaos olurdu.
👉 Mediator, işte bu kule rolünü üstlenir.



---
<br/>

---

##  🏗 Yapı (Structure)

<b>1.Mediator Arayüzü<b/>

➵Bileşenlerin haberleşme yöntemlerini tanımlar.
➵Genellikle Notify veya Send gibi tek bir metot içerir.

<b>2.Concrete Mediator (Somut Arabulucu)<b/>

➵Bileşenler arasındaki iletişim kurallarını içerir.
➵Tüm bileşenlere referans tutabilir.

<b>3.Components (Bileşenler)<b/>

➵İş mantığını barındırır.
➵Diğer bileşenleri bilmez, sadece Mediator’a haber verir.

```bash
ComponentA ---> Mediator <--- ComponentB
       |                          |
       +----------> ComponentC <---+

```


---




## 🎯 Avantajlar

✔ Bileşenler arası gevşek bağlılık sağlar. <br/>
✔ Yeniden kullanılabilirlik artar. <br/>
✔ İletişim kuralları tek bir noktada (Mediator’da) toplanır. <br/>

## ⚠️ Dezavantajlar

✘ Mediator sınıfı çok fazla sorumluluk alabilir. <br/>
✘ Karmaşık senaryolarda “God Object” haline gelebilir. <br/>


---
<br/>
<img width="1081" height="401" alt="image" src="https://github.com/user-attachments/assets/efc56b0b-daf1-4927-9247-be2b48221a52" />
<br/>


## 🌸 Template Method Tasarım Deseni
<br/>
Türü: Behavioral (Davranışsal)
<br/>


---
## 🎯 Amaç (Intent)

Template Method, bir algoritmanın iskeletini (sırasını) üst sınıfta tanımlar;
ancak algoritmanın belirli adımlarını alt sınıfların yeniden yazmasına (override) izin verir.

👉 Böylece algoritmanın genel akışı sabit kalır, ama alt sınıflar detayları özelleştirebilir.

---
<br/>

---

## ❓ Problem


Bir veri madenciliği uygulaması düşünelim:

➵Kullanıcı, uygulamaya farklı formatlarda belgeler (DOC, CSV, PDF) yükleyebiliyor.
➵Her format için farklı işleme kodu yazmanız gerekiyor.

Sorunlar:

1.Kod tekrarları oluşuyor: Açma, kapama, raporlama gibi adımlar hep aynı.
2.İstemci kodu karmaşıklaşıyor: Her format için ayrı koşul (if-else) kullanmak gerekiyor.

👉 Yani algoritma yapısı aynı, ama bazı adımlar formatlara göre değişiyor.




<br/>


---


<br/>


---
## 💡 Çözüm 

Template Method deseni öneriyor ki:

1.Algoritmayı adımlara ayır.
2.Bu adımları üst sınıfta tanımla.
3.Algoritmanın akışını bir template method içinde sırayla çalıştır.
4.Alt sınıflar, sadece kendilerine özel adımları override etsin.

Örneğin:

➵OpenFile() → Her format için farklı (abstract) <br/>
➵ExtractData() → Her format için farklı (abstract) <br/>
➵AnalyzeData() → Ortak, üst sınıfta (default implementation) <br/>
➵GenerateReport() → Ortak, üst sınıfta (default implementation) <br/>

📌 Böylece:

➵Genel algoritma akışı korunur.
➵Kod tekrarları ortadan kalkar.
➵İstemci, sadece üst sınıf tipini kullanarak (polymorphism) tüm alt sınıflarla çalışabilir..


---

<br/>

---

##  🌍 Gerçek Dünya Örneği

Hava Trafik Kontrol Kulesi ✈️

Toplu Konut İnşaatı 🏠

->Her evin temel iskeleti aynıdır (temel atma, duvar örme, tesisat).
->Ama bazı adımlar müşteriye göre değiştirilebilir (boya rengi, pencere tasarımı, iç mimari).

👉 Yani şablon aynı kalır, ama detaylar özelleştirilebilir.


---
<br/>

---

##  🏗 Yapı (Structure)



<b>Abstract Class (Soyut Sınıf)<b/>

a.Template method’u tanımlar.
a.Adım metotlarını (Step1, Step2 …) içerir.
a.Bazıları abstract (zorunlu), bazıları varsayılan (opsiyonel) olabilir.

<b>Concrete Class (Somut Sınıf)<b/>
b.Abstract adımları override eder.
b.İsterse varsayılanları da değiştirebilir.

## 📌 Diyagram:
```bash

AbstractClass
 ├── TemplateMethod()
 ├── Step1() (abstract)
 ├── Step2() (abstract)
 └── Step3() (default)

ConcreteClassA
 └── Step1(), Step2() override

ConcreteClassB
 └── Step1(), Step2() override

```



---




##  🎯 Avantajlar

✔ Kod tekrarını azaltır. <br/>
✔ Ortak algoritma iskeletini korur.<br/>
✔ Yeni varyasyon eklemek kolaydır (sadece alt sınıf oluştur).<br/>
✔ İstemci kodu basitleşir (polymorphism).<br/>

##  ⚠️ Dezavantajlar

✘ Alt sınıflar arttıkça bakım yükü artabilir.<br/>
✘ Algoritma iskeletini değiştirmek için base class’ı düzenlemek gerekir.<br/>

---
<br/>
<img width="1086" height="413" alt="image" src="https://github.com/user-attachments/assets/dd2e2bb2-3050-4865-bc3e-e3ba83ec7079" />
<br/>


## 🌺 Observer Tasarım Deseni
<br/>
Türü: Behavioral (Davranışsal)
<br/>


---
## 🎯 Amaç (Intent)

Observer, bir nesnede meydana gelen olayları diğer nesnelere bildirmek için abonelik (subscription) mekanizması tanımlar. <br/>

👉 Yani: Bir nesne (publisher) değişiklik yaptığında, ona abone olmuş tüm nesneler (subscribers) otomatik olarak haberdar edilir.

---
<br/>

---

## ❌ Problem

Bir müşteri ve mağaza senaryosu düşünelim:

➵Müşteri, yeni bir ürünün (ör. iPhone) mağazaya gelip gelmediğini öğrenmek istiyor.

Çözümler:

1.Müşteri her gün mağazaya gidip kontrol eder → Zaman kaybı ⏳ <br/>
2.Mağaza tüm müşterilere e-posta atar → İlgilenmeyenler için spam 📩<br/>

👉 Sorun:
Ya müşteri boşuna zaman kaybeder, ya da mağaza gereksiz yere herkese bildirim gönderir.


<br/>


---


<br/>


---
## 💡 Çözüm 

➵ <b>Publisher (Yayıncı):<b/> Durumu değişen nesnedir.
➵<b>Subscriber (Abone):<b/> O duruma ilgi duyan nesnelerdir.

➵Observer deseni, publisher’a bir abonelik mekanizması ekler:
➵Aboneler listeye eklenebilir veya listeden çıkabilir.

Publisher’da bir olay olduğunda, listedeki tüm abonelere bildirim (update) gönderilir.

👉 Böylece:

➵İlgilenen aboneler bilgilendirilir.
➵Publisher, somut subscriber sınıflarını bilmez. Sadece onların interface’ini kullanır.


---

<br/>

---

##  🌍 Gerçek Dünya Örneği

Dergi / Gazete Aboneliği 📰

a.Bir dergiye abone olduğunuzda, her yeni sayı otomatik olarak size gönderilir. <br/>
a.Dergiyi almak için mağazaya gitmenize gerek yoktur.<br/>
a.İstediğinizde aboneliği iptal edebilirsiniz.<br/>

👉 Publisher (dergi) → Subscriber (siz)


---
<br/>

---

##  🏗 Yapı (Structure)




<b>Publisher (Yayıncı)<b/>

➵Aboneleri listeler.
➵Subscribe(), Unsubscribe(), Notify() metotlarını içerir.

<b>Subscriber (Abone)<b/>

➵Bildirim almak için Update() metodunu tanımlar.

<b>Concrete Subscriber<b/>

➵Bildirim geldiğinde belirli bir işlem yapar.

<b>Client<b/>

➵Publisher ve Subscriber nesnelerini oluşturur.
➵Aboneleri yayıncıya kaydeder.

## 📌 Diyagram:
```bash

Publisher
 ├── Subscribe()
 ├── Unsubscribe()
 └── Notify()

Subscriber
 └── Update()

ConcreteSubscriberA
 └── Update() override

ConcreteSubscriberB
 └── Update() override

```



---





##  🎯 Avantajlar

✔ Publisher ve Subscriber gevşek bağlıdır (loose coupling). <br/>
✔ Yeni subscriber eklemek kolaydır.<br/>
✔ Tek publisher → çok subscriber ilişkisini etkin yönetir.<br/>

##  ⚠️ Dezavantajlar

✘ Subscriber sayısı çok fazla olursa performans sorunu olabilir.<br/>
✘ Publisher’ın bildirim sıklığı iyi yönetilmezse spam riski oluşur.<br/>

---
<br/>
<img width="1101" height="406" alt="image" src="https://github.com/user-attachments/assets/4c404ad7-b2dd-4f1c-9071-2fa3217c5d8b" />
<br/>


## 🌻 Repository Design Pattern
<br/>
Also known as: Data Access Pattern
<br/>


---
## 🎯 Amaç (Intent)

Repository Design Pattern, veri erişim mantığını iş mantığından ayırarak uygulamayı daha düzenli, test edilebilir ve sürdürülebilir hale getirmeyi amaçlar.

Repository, uygulamanın veri katmanı ile domain/business katmanı arasında bir aracı (abstraction layer) görevi görür.

---
<br/>

---

## ❌ Problem

Bir uygulamada iş mantığı sınıflarının doğrudan veritabanı erişim kodlarıyla dolu olduğunu düşünelim.

Örneğin:

a.Bir CustomerService sınıfı hem müşteri ile ilgili iş mantığını hem de SQL sorgularını içeriyor.

Bu durumda:

b.Kod okunabilirliği azalır.

b.Veri kaynağı değişirse (SQL → MongoDB, API vb.) her yerde değişiklik yapmak gerekir.

b.Test etmek zorlaşır çünkü gerçek veritabanına bağımlı hale gelir.


<br/>


---


<br/>


---
## 💡 Çözüm 


Repository Pattern, veri erişim işlemlerini kapsülleyen repository sınıfları oluşturmayı önerir.


➵ Repository, belirli bir entity için (Customer, Product, Order vb.) CRUD işlemlerini (Create, Read, Update, Delete) yapar.


➵ İş mantığı sınıfları repository üzerinden veriye erişir, SQL veya Entity Framework kodunu bilmez.


➵ Bu sayede uygulamanın veri erişim katmanı soyutlanır.

## Örneğin

```bash
public interface ICustomerRepository
{
    Customer GetById(int id);
    IEnumerable<Customer> GetAll();
    void Add(Customer customer);
    void Update(Customer customer);
    void Delete(int id);
}

```

## İş Mantığı

```bash

public class CustomerService
{
    private readonly ICustomerRepository _repository;

    public CustomerService(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public void RegisterCustomer(Customer customer)
    {
        // İş mantığı burada
        _repository.Add(customer);
    }
}

```



---

<br/>

---

##  🌍 Gerçek Dünya Örneği

Bir şirketin sekreterini düşün.

a.Patron doğrudan herkesle iletişime geçmek yerine, sekretere söyler.

a.Sekreter (repository) patron adına işleri organize eder (arama, mesaj, randevu).

a.Patron işine (business logic) odaklanırken, sekreter de veri akışını yönetir.

Aynı şekilde repository de iş katmanı ile veri kaynağı arasında bir aracı görevi görür.

---
<br/>

---

##  🏗 Yapı (Structure)





➵
Repository Pattern’in yapısı şu şekilde özetlenebilir:

<b> 1.Entity (Domain Class):<b/>
Veritabanındaki tabloları temsil eden sınıf (Customer, Product, Order).

<b> 2.Repository Interface:<b/>
CRUD operasyonlarını tanımlayan arayüz (ICustomerRepository).

<b>  3.Concrete Repository:<b/>
Veritabanı erişim detaylarını barındırır (EF Core, Dapper, ADO.NET).

<b> 4.Service/Business Layer: <b/>
Repository üzerinden veriye ulaşır. SQL bilmez.

<b>4.Client:<b/>
Servisleri çağıran katman (Controller, UI, API).


```bash
Client → Service Layer → Repository → Data Source (DB/API)


```



---





##  🎯 Avantajlar

✔Soyutlama sağlar: Veri erişim kodu iş mantığından ayrılır.<br/>

✔Test edilebilirlik: Mock repository kullanarak unit test yazmak kolaylaşır.<br/>

✔Esneklik: Veri kaynağı değiştiğinde (SQL’den NoSQL’e geçiş gibi) iş katmanı etkilenmez.<br/>

✔Yeniden kullanılabilirlik: Aynı repository farklı servisler tarafından kullanılabilir.<br/>

✔Bakım kolaylığı: DB erişim kodları tek bir yerde toplandığı için yönetimi kolaydır.<br/>

##  ⚠️ Dezavantajlar

✘ Ek karmaşıklık: Küçük projelerde ekstra katman kod yükü yaratabilir.<br/>

✘ Generic repository sorunları: Çok soyutlanmış generic repository’ler bazı özel sorguları yönetmekte yetersiz kalabilir.<br/>

✘ Over-engineering riski: Basit CRUD işlemleri için fazla yapılandırma gerekebilir.<br/>

✘ Performans sorunları: Yanlış tasarlanmış repository, gereksiz abstraction katmanından dolayı ek maliyet yaratabilir.<br/>

---
<br/>
<img width="1107" height="410" alt="image" src="https://github.com/user-attachments/assets/7f332f05-0fe5-4f1e-9892-565947e1b90f" />
<br/>


## 🎣 Unit of Work Design Pattern
<br/>
Also known as: Transaction Script Manager
<br/>


---
## 🎯 Amaç (Intent)

Unit of Work, birden fazla repository ile yapılan işlemleri tek bir işlem (transaction) altında toplayarak:

Tüm değişikliklerin birlikte başarıyla kaydedilmesini

Veya tamamen geri alınmasını (rollback)

sağlar.

---
<br/>

---

## ❌ Problem

Bir e-ticaret uygulamasında:

Sipariş verildiğinde Orders tablosuna kayıt yapılır.

Aynı anda Stock tablosundan ürün düşülür.

Ayrıca Payments tablosuna ödeme bilgisi kaydedilir.

👉 Eğer bu işlemlerden biri başarısız olursa (ör. ödeme başarısız), diğer işlemler de geri alınmalıdır.
Repository’ler bağımsız çalıştığında veri tutarsızlığı oluşur.
<br/>


---


<br/>


---
## 💡 Çözüm 


Unit of Work tüm repository işlemlerini tek bir transaction altında toplar.

Begin Transaction → İşlemler başlar

➵ Repository’ler aracılığıyla entity değişiklikleri yapılır

➵ Commit() → Tüm değişiklikler veritabanına kaydedilir

➵ Rollback() → Hata durumunda tüm değişiklikler geri alınır







---

<br/>

---

##  🌍 Gerçek Dünya Örneği

Bir bankada para transferi:

Ali’nin hesabından para çekilir.

Veli’nin hesabına para yatırılır.

Eğer yatırma işlemi başarısız olursa, çekilen para geri yatırılır.
Bu işlemler tek bir transaction gibi çalışır.
---
<br/>

---

##  🏗 Yapı (Structure)



➵<b>Entity (Domain Class): Veritabanı tablolarını temsil eder.<b/>

➵<b>Repository: Tek tabloya yönelik CRUD işlemleri yapar.<b/>

➵<b>Unit of Work: Tüm repository’leri ve transaction’ı yönetir.<b/>

➵<b>Service Layer: İş mantığını yürütür.<b/>

Client: API veya UI katmanı.

```bash
Client → Service Layer → Unit of Work → Repositories → Database



```



---





##  🎯 Avantajlar


✔Transaction yönetimi: Birden fazla işlem tek transaction altında yapılır.<br/>

✔Veri tutarlılığı: Hata durumunda rollback yapılır.<br/>

✔Merkezi kontrol: Tüm repository işlemleri tek noktadan yönetilir.<br/>

✔Test kolaylığı: Mock Unit of Work ile test yazmak kolaydır.<br/>

##  ⚠️ Dezavantajlar

✘ Ek karmaşıklık: Küçük projelerde gereksiz olabilir.<br/>

✘ Performans maliyeti: Büyük transaction’lar performansı düşürebilir.<br/>

✘ Over-engineering riski: Basit CRUD projelerinde gereksiz soyutlama olur.<br/>

---
<br/>
<img width="1103" height="403" alt="image" src="https://github.com/user-attachments/assets/1ba1d1fe-44c7-4907-9f63-70f6316af3d8" />
<br/>

## 🌳 Composite Design Pattern
<br/>
Also known as: Object Tree
<br/>


---
## 🎯 Amaç (Intent)

Composite, nesneleri ağaç yapıları halinde düzenlemenize ve bu yapılarla tekil nesneymiş gibi çalışmanıza olanak tanıyan bir structural design pattern’dir.

---
<br/>

---

## ❌ Problem

Bir sipariş sisteminiz olduğunu düşünün:

a.Product → Tek bir ürün (ör. Laptop).

a.Box → İçinde ürünler ve başka kutular olabilir.

👉 Müşteri siparişi verdiğinde, fiyatı hesaplamak için:

a.Kutuları açıp içindekileri dolaşmak

a.İç içe geçmiş kutuların seviyelerini bilmek

a.Farklı sınıflar (Product, Box) için ayrı mantık yazmak gerekir.

Bu, kodun karmaşık ve bakımı zor hale gelmesine yol açar.
<br/>


---


<br/>


---
## 💡 Çözüm 

Composite, hem Product hem de Box için ortak bir arayüz (IComponent) tanımlar.

➵Product (Leaf): Fiyatını direkt döndürür.

➵Box (Composite): İçindekileri dolaşır, fiyatlarını toplar ve kendi ek maliyetini (ör. paketleme ücreti) ekleyebilir.

👉 Böylece müşteri için fark etmez:
Bir ürün de olsa, bir kutu da olsa aynı arayüz ile işlem yapılır.





---

<br/>

---

##  🌍 Gerçek Dünya Örneği

Askeri hiyerarşi:

➵Ordu → Tümen → Tugay → Tabur → Takım → Asker

➵Emir en üstten en alta kadar aynı şekilde aktarılır.
Her seviye, altındaki tüm yapıyı yönetir.
---
<br/>

---

##  🏗 Yapı (Structure)


```bash
Client → Component
          ├── Leaf (Product)
          └── Composite (Box)



```
➵<b>Component (IComponent): Ortak operasyonları tanımlar (GetPrice()).<b/>

➵<b>Leaf (Product): Alt elemanı olmayan, temel iş yapan sınıf.<b/>

➵<b>Composite (Box): Alt elemanlar (Product/Box) tutar, işleri onlara delege eder.<b/>

➵<b>Client: Hem Product hem de Box ile aynı şekilde çalışır.<b/>







---





##  🎯 Avantajlar


✔Basit kullanım: Client tarafı, tekil ürün mü yoksa kutu mu bilmek zorunda değil.<br/>

✔Özyinelemeli yapı: Sınırsız iç içe kutu/alt eleman destekler.<br/>

✔Açık-uzatılabilirlik (Open/Closed Principle): Yeni tür bileşenler eklenebilir.<br/>

##  ⚠️ Dezavantajlar

✘ Aşırı soyutlama: Basit senaryolarda gereksiz karmaşıklık yaratabilir.<br/>

✘ Tip güvenliği zayıflar: Farklı türde objeler aynı arayüz üzerinden yönetildiği için kontrol zor olabilir.<br/>

✘ Performans maliyeti: Çok derin ağaç yapılarında özyinelemeli işlemler yavaş olabilir.<br/>

---
<br/>
<img width="397" height="354" alt="image" src="https://github.com/user-attachments/assets/7ab61a80-3fa1-457e-b14e-e82b586be4e0" />
<br/>


## 🌀 Iterator Design Pattern
<br/>

<br/>


---
## 🎯 Amaç (Intent)

Iterator, bir behavioral (davranışsal) tasarım deseni olup; bir koleksiyonun (list, stack, tree, graph vb.) elemanlarını, koleksiyonun iç yapısını açığa çıkarmadan sıralı bir şekilde gezmenizi sağlar.

---
<br/>

---

## ❌ Problem

Koleksiyonlar yazılım geliştirmede en çok kullanılan veri yapılarındandır. Ancak:

a.Her koleksiyon elemanlarını farklı şekilde tutar (liste, yığın, ağaç, grafik).

a.Koleksiyonun elemanlarına erişmek için farklı yöntemler gerekir.

a.Bazen farklı gezinme algoritmaları (ör. derinlik öncelikli, genişlik öncelikli, rastgele erişim) gerekebilir.

Eğer tüm bu algoritmalar koleksiyonun içine eklenirse:

a.Koleksiyonun asıl amacı olan veri saklama bulanıklaşır.

a.Farklı koleksiyonlara erişmek için client kodu belirli koleksiyon sınıflarına bağımlı hale gelir.

---


<br/>


---
## 💡 Çözüm 

Iterator deseni, gezinme (traversal) davranışını koleksiyonun içinden ayırarak ayrı bir Iterator nesnesine taşır.

➵Iterator, gezinme algoritmasını kapsüller.

➵Koleksiyonun mevcut durumunu (current position, kalan eleman sayısı) kendi içinde tutar.

➵Bir koleksiyon için birden fazla iterator aynı anda bağımsız olarak çalışabilir.

➵Tüm iterator’lar aynı arayüzü (interface) uygular → Böylece client kodu, koleksiyon tipinden bağımsız olur.

👉 Yeni bir gezinme algoritması gerektiğinde sadece yeni bir Iterator sınıfı yazılır; koleksiyon veya client değiştirilmez.



---

<br/>

---

##  🌍 Gerçek Dünya Örneği

Roma’da gezilecek yerler koleksiyonunu düşün:

b.Kendi başına gezinmek → kontrolsüz ve zaman kaybettirir.

b.Telefon navigasyonu → ucuz ve pratik bir iterator.

b.Yerel rehber → daha pahalı ama özel, kişiselleştirilmiş bir iterator.

Her biri aynı koleksiyonu (Roma’daki tarihi yerler) farklı şekilde gezme algoritmasıyla temsil eder.
---
<br/>

---

##  🏗 Yapı (Structure)


1.Iterator (Arayüz) → Gezinti için gerekli metotları tanımlar (Next(), HasNext() vb.).

2.ConcreteIterator → Belirli bir gezinme algoritmasını uygular, mevcut pozisyonu takip eder.

3.Collection (Arayüz) → Uyumlu iterator döndüren metotları tanımlar.

4.ConcreteCollection → Belirli bir ConcreteIterator döndürür.

5.Client → Koleksiyon ve iterator ile sadece arayüzler üzerinden çalışır.

🖥️ Pseudocode


```bash
// Iterator arayüzü
public interface IIterator<T>
{
    bool HasNext();
    T Next();
}

// Concrete Iterator
public class ListIterator<T> : IIterator<T>
{
    private readonly List<T> _collection;
    private int _position = 0;

    public ListIterator(List<T> collection)
    {
        _collection = collection;
    }

    public bool HasNext() => _position < _collection.Count;

    public T Next() => _collection[_position++];
}

// Collection arayüzü
public interface ICollection<T>
{
    IIterator<T> CreateIterator();
}

// Concrete Collection
public class ProductCollection : ICollection<string>
{
    private List<string> _items = new List<string>();

    public void Add(string item) => _items.Add(item);

    public IIterator<string> CreateIterator()
    {
        return new ListIterator<string>(_items);
    }
}

// Client
class Program
{
    static void Main()
    {
        var products = new ProductCollection();
        products.Add("Laptop");
        products.Add("Telefon");
        products.Add("Tablet");

        var iterator = products.CreateIterator();
        while (iterator.HasNext())
        {
            Console.WriteLine(iterator.Next());
        }
    }
}




```

---





##  🎯 Avantajlar

✔ Koleksiyonların iç yapısı gizlenir.<br/>
✔ Farklı gezinme algoritmaları kolayca eklenebilir.<br/>
✔ Client kodu, koleksiyon tipine bağımlı olmaz.<br/>
✔ Aynı koleksiyon üzerinde birden fazla iterator kullanılabilir.<br/>

##  ⚠️ Dezavantajlar

✘  Küçük projelerde fazladan karmaşıklık ekleyebilir.<br/>

✘ Fazla sayıda iterator sınıfı, bakım maliyetini artırabilir.<br/>

✘ Çok büyük koleksiyonlarda iteratorların durum takibi ek bellek maliyeti oluşturabilir.<br/>

---
<br/>
<img width="1002" height="453" alt="image" src="https://github.com/user-attachments/assets/b0736139-f4da-4498-9c10-b5bc1790c3f4" />
<br/>

## 🏛️ Facade Design Pattern
<br/>

<br/>


---
## 🎯 Amaç (Intent)

Facade, bir structural (yapısal) tasarım deseni olup; karmaşık bir sistemin (library, framework, çoklu sınıflar) üzerinde, kullanımı kolaylaştıran basit bir arayüz sağlar.
---
<br/>

---

## ❌ Problem

Bir uygulamanın karmaşık bir kütüphane veya framework ile çalışması gerektiğini düşünelim.

a.Birçok nesnenin doğru sırada başlatılması,

a.Bağımlılıkların takip edilmesi,

a.Metotların uygun sırayla çağrılması gerekir.

Bu durumda:

b.İş mantığı, üçüncü parti sınıfların uygulama detaylarına sıkı sıkıya bağımlı hale gelir.

b.Kod zor anlaşılır ve bakımı zor olur.

---


<br/>


---
## 💡 Çözüm 

Facade deseni, bu karmaşık sistemi saran basit bir ara yüz sınıfı sağlar.

Facade, alt sistemin karmaşıklığını gizler.

Kullanıcıya yalnızca gerekli olan metotları sunar.

Gereksiz detayları dışarı sızdırmaz.

Örneğin:
Bir uygulama profesyonel bir video dönüştürme kütüphanesi kullanıyor olabilir.
Ama uygulamanın ihtiyacı yalnızca:

```bash
videoFacade.Encode("cat.mp4", "mp4");

```


---

<br/>

---

##  🌍 Gerçek Dünya Örneği

Telefonla sipariş verdiğinizi düşünün:

a.Operatör, sizin için Facade görevi görür.

a.Sipariş sistemine, ödeme altyapısına ve kargoya erişim sağlar.

a.Siz yalnızca bir numara arayıp sipariş verirsiniz → karmaşık süreçleri bilmenize gerek yoktur.
---
<br/>

---

##  🏗 Yapı (Structure)


<b>Facade → Alt sistemin karmaşıklığını saran basit arayüzü sağlar.<b/>

<b>Additional Facade → Farklı özellikleri ayırmak için ek facade sınıfları olabilir.<b/>

<b>Complex Subsystem → Alt sistemin karmaşık sınıflarıdır (birbirleriyle doğrudan çalışırlar).<b/>

<b>Client → Alt sisteme doğrudan erişmek yerine Facade üzerinden erişir.<b/>

🖥️ Pseudocode


```bash
// Karmaşık alt sistem
public class VideoFile { }
public class Codec { }
public class MPEG4Codec : Codec { }
public class OggCodec : Codec { }

public class CodecFactory
{
    public Codec Extract(VideoFile file)
    {
        Console.WriteLine("Codec extracted.");
        return new MPEG4Codec();
    }
}

public class BitrateReader
{
    public static VideoFile Read(string filename, Codec codec)
    {
        Console.WriteLine("Bitrate reading...");
        return new VideoFile();
    }

    public static void Convert(VideoFile buffer, Codec codec)
    {
        Console.WriteLine("Bitrate converting...");
    }
}

// Facade
public class VideoConversionFacade
{
    public void ConvertVideo(string filename, string format)
    {
        CodecFactory codecFactory = new CodecFactory();
        VideoFile file = new VideoFile();
        Codec codec = codecFactory.Extract(file);
        VideoFile buffer = BitrateReader.Read(filename, codec);
        BitrateReader.Convert(buffer, codec);

        Console.WriteLine($"Video converted to {format} successfully!");
    }
}

// Client
class Program
{
    static void Main()
    {
        var facade = new VideoConversionFacade();
        facade.ConvertVideo("cat-video.avi", "mp4");
    }
}


```

---





##  🎯 Avantajlar

✔ Karmaşık sistemi basit bir arayüzle gizler.<br/>
✔ Bağımlılıkları azaltır, client sadece Facade’i bilir.<br/>
✔ Kodun okunabilirliği ve bakımı kolaylaşır.<br/>
✔ Alt sistemde değişiklik olsa bile Facade sabit kalabilir.<br/>

##  ⚠️ Dezavantajlar

✘ Fazla özellik eklenirse, Facade karmaşıklaşabilir (yeni bir “mini framework” haline gelir).<br/>
✘ Alt sistemdeki güçlü işlevsellikler saklanabilir → kullanıcı tüm özelliklere erişemez.<br/>
✘ Ek soyutlama katmanı olduğundan, küçük projelerde gereksiz karmaşıklık yaratabilir.<br/>

---
<br/>
<img width="1049" height="446" alt="image" src="https://github.com/user-attachments/assets/849b8699-6fdd-477c-a79c-3f33512c0e07" />
<br/>

## 🎭 Decorator Design Pattern
<br/>

<br/>


---
## 🎯 Amaç (Intent)

Decorator, bir structural (yapısal) tasarım deseni olup, nesnelere yeni davranışlar eklemenin bir yolunu sunar.
Bunu, nesneleri aynı arayüzü uygulayan özel “sarmalayıcı” (wrapper) nesneler içine alarak yapar.

---
<br/>

---

## ❌ Problem

Bir bildirim (notification) kütüphanesi geliştirdiğinizi düşünün.
Başta sadece e-posta bildirimi gönderen Notifier sınıfınız var.

Daha sonra:

a.Kullanıcılar SMS bildirimi istiyor.

a.Bazıları Facebook bildirimi istiyor.

a.Kurumsal kullanıcılar ise Slack bildirimi talep ediyor.

👉 İlk çözüm: Notifier sınıfını miras alıp her biri için alt sınıflar (subclass) oluşturmak.
Ama sorun şu:

b.Birden fazla bildirim türü aynı anda kullanılamıyor.

b.Tüm kombinasyonları oluşturmak için çok fazla alt sınıf gerekir (sınıf patlaması / combinatorial explosion).

---


<br/>


---
## 💡 Çözüm 

Decorator deseni ile:

a.Her bildirim türü için bir decorator sınıfı oluşturulur.

a.Tüm sınıflar aynı INotifier arayüzünü uygular.

a.Bir Notifier nesnesi, birden fazla decorator ile sarılabilir.

🔑 Özet:

b.EmailNotifier → Temel bildirim.

b.SMSDecorator, SlackDecorator, FacebookDecorator → Ek özellikleri dinamik olarak ekler.

b.Decorator’lar birbirine zincirleme eklenebilir (stack).

---

<br/>

---

##  🌍 Gerçek Dünya Örneği

Kıyafet giymek 🎽🧥🌧️:

a.Önce tişört giyersiniz (temel nesne).

a.Üşüyünce kazak giyersiniz (decorator).

a.Daha çok üşüyünce mont eklersiniz (decorator).

a.Yağmur yağarsa yağmurluk giyersiniz (decorator).

👉 İhtiyaca göre katmanlı bir şekilde özellik eklenir, ve istenildiğinde kolayca çıkarılabilir.
---
<br/>

---

##  🏗 Yapı (Structure)


<b>1.Component → Ortak arayüz (INotifier).<b/>

<b>2.Concrete Component → Temel sınıf (EmailNotifier).<b/>

<b>3.Base Decorator → Diğer INotifier nesnelerini saran sınıf.<b/>

<b>4.Concrete Decorators → Yeni davranışlar ekleyen sınıflar (SMSDecorator, SlackDecorator).<b/>

<b>5.Client → Nesneleri doğrudan değil, decorator zinciri üzerinden kullanır.<b/>

🖥️ Pseudocode


```bash

// Ortak arayüz
public interface INotifier
{
    void Send(string message);
}

// Temel bileşen
public class EmailNotifier : INotifier
{
    public void Send(string message)
    {
        Console.WriteLine($"Email sent: {message}");
    }
}

// Base Decorator
public abstract class NotifierDecorator : INotifier
{
    protected INotifier _wrappee;

    public NotifierDecorator(INotifier notifier)
    {
        _wrappee = notifier;
    }

    public virtual void Send(string message)
    {
        _wrappee.Send(message);
    }
}

// Concrete Decorators
public class SMSDecorator : NotifierDecorator
{
    public SMSDecorator(INotifier notifier) : base(notifier) { }

    public override void Send(string message)
    {
        base.Send(message);
        Console.WriteLine($"SMS sent: {message}");
    }
}

public class SlackDecorator : NotifierDecorator
{
    public SlackDecorator(INotifier notifier) : base(notifier) { }

    public override void Send(string message)
    {
        base.Send(message);
        Console.WriteLine($"Slack message sent: {message}");
    }
}

// Client
class Program
{
    static void Main()
    {
        INotifier notifier = new EmailNotifier();
        notifier = new SMSDecorator(notifier);
        notifier = new SlackDecorator(notifier);

        notifier.Send("🚨 Fire in the server room!");
    }
}




```

📌 Çıktı:
```bash

Email sent: 🚨 Fire in the server room!
SMS sent: 🚨 Fire in the server room!
Slack message sent: 🚨 Fire in the server room!



```


---





##  🎯 Avantajlar

✔ Nesnelere çalışma zamanında (runtime) yeni davranış eklenebilir.<br/>

✔ Alt sınıf patlaması (subclass explosion) engellenir.<br/>

✔ İstediğiniz kadar dekoratörü birleştirip zincirleme kullanabilirsiniz.<br/>

✔ Açık-Kapalı Prensibi (OCP) uygulanır → mevcut sınıflar değiştirilmez.<br/>


##  ⚠️ Dezavantajlar

✘ Çok fazla decorator zincirlenirse takip edilmesi zorlaşabilir.<br/>
✘ Basit işler için gereksiz soyutlama katmanı ekleyebilir.<br/>
✘ Debug yapmak zor olabilir (hangi decorator’un ne yaptığı karışabilir).<br/>

---
<br/>
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

