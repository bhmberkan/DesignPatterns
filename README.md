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

Bir çevrim içi sipariş sistemi üzerinde çalıştığınızı düşünün:<br/>
➵Yalnızca doğrulanmış kullanıcıların sipariş oluşturabilmesini istiyorsunuz.<br/>
➵Yönetici yetkisine sahip kullanıcıların ise tüm siparişlere erişim hakkı olmalı.<br/>
➵Bu kontrollerin sıralı bir şekilde yapılması gerektiğini fark ettiniz.<br/>
➵İlk olarak, sistem kullanıcıyı doğrulamalı. Eğer kimlik doğrulama başarısız olursa diğer adımları yapmaya gerek yoktur.<br/>
➵Daha sonra verilerin güvenliği için girdi temizliği (validation/sanitization) yapılmalı.<br/>
➵Brute-force saldırılarını engellemek için aynı IP’den gelen tekrar eden hatalı girişler filtrelenmeli.<br/>
➵Performans için, önbellek kontrolü (cache) yapılmalı ve uygun yanıt varsa doğrudan dönülmeli.<br/>
<br/>

##  Eksiklikler
👉 Ancak her yeni kontrol eklendiğinde kod karmaşıklaştı, bakımın zorlaşması  ve tekrar kullanılabilirliği azaltır.
---


<br/>


---
## 💡 Çözüm

Chain of Responsibility, bu tür kontrolleri bağımsız nesnelere (handler) ayırmayı önerir.<br/>
➵Her kontrol, yalnızca tek bir sorumluluğa sahip ayrı bir sınıfta bulunur.<br/>
➵Bu sınıflar ortak bir arayüzü uygular (örneğin Handle(request) metodu).<br/>
➵İşleyiciler zincir şeklinde bağlanır.<br/>
➵Her işleyici, isteği işler ve zincirdeki bir sonraki işleyiciye aktarıp aktarmamaya kendisi karar verir.<br/>
<br/>

##  Artılar
<br/>
👉 Böylece kontroller bağımsız, modüler, yeniden kullanılabilir ve dinamik olarak zincirlenebilir hale gelir.
---

<br/>

---

##  🌍 Gerçek Dünya Örneği

Bir donanım kurulumunda sorun yaşadınız ve teknik destek hattını aradınız:<br/>

1.Önce otomatik telesekreter yanıt verir (genel çözümler).<br/>
2.Sonra müşteri temsilcisine bağlanırsınız (temel yardım).<br/>
3.Sorun hâlâ çözülmezse çağrı mühendise iletilir.<br/>
4.Sonunda doğru kişiye ulaşıp çözümü elde edersiniz.<br/>
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
<img width="1027" height="250" alt="image" src="https://github.com/user-attachments/assets/2a588f42-7f29-44d2-8b8f-ff3f313b9a38" />
<br/>
<img width="864" height="144" alt="image" src="https://github.com/user-attachments/assets/bee207c0-ddf4-40bb-9c67-306e43ecb587" />
<br/>
<img width="1027" height="239" alt="image" src="https://github.com/user-attachments/assets/0a30d138-b0dc-4d07-827b-7b71af866f61" />
<br/>
<img width="1070" height="179" alt="image" src="https://github.com/user-attachments/assets/353da8ce-c319-45d2-b17d-265c6c3d7143" />




## ⚡ CQRS (Command Query Responsibility Segregation)
<br/>
Diğer Adlarıyla: Command Query Separation
<br/>


---
## 🎯 Amaç (Intent)


CQRS, veri okuma (Query) ve yazma (Command) işlemlerini ayrı modeller üzerinden ele alan bir tasarım desenidir.<br/>
Bu desen ile:
Veri okuma operasyonları hızlı ve optimize şekilde yapılabilir.<br/>
Veri yazma işlemleri ise ayrı bir akışta yönetilir.<br/>

👉 Temel amaç, okuma ve yazma operasyonlarının sorumluluklarını ayırarak daha ölçeklenebilir, anlaşılır ve yönetilebilir bir mimari kurmaktır.
---
<br/>

---

## ❓ Problem

Geleneksel uygulamalarda aynı model hem okuma hem de yazma işlemlerini karşılar.<br/>
Örneğin bir sipariş sistemi düşünelim:<br/>
➵Kullanıcı sipariş oluşturur (yazma).<br/>
➵Sipariş listesi görüntülenir (okuma).<br/>
<b>Zamanla sistem büyüdükçe:<b/>
➵Okuma işlemleri çok sık yapılır.<br/>
➵Yazma işlemleri daha karmaşık hale gelir (transaction, business rules).<br/>
➵Tek model üzerinde bu iki sorumluluğun birleşmesi, kodun karmaşık, zor test edilebilir ve bakımı maliyetli olmasına yol açar.<br/>

<br/>


---


<br/>


---
## 💡 Çözüm 

CQRS, tek model yerine:
<b>Command Model (Yazma):<b/>
➵Veritabanına veri ekleme, güncelleme, silme gibi değişiklik yapan işlemler.<br/>
➵“Komut” mantığıyla çalışır.<br/>
➵Genelde DTO veya ayrı Command nesneleri ile temsil edilir.<br/>
<b>Query Model (Okuma):<b/>
➵Sadece veri okuma, raporlama, listeleme işlemleri.<br/>
➵Performans için özelleştirilmiş olabilir (örneğin farklı DTO’lar, View modeller).<br/>


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
<img width="998" height="183" alt="image" src="https://github.com/user-attachments/assets/ca0ad2f2-355a-4b60-95dd-d03fb745b56b" />
<br/>
<img width="1004" height="390" alt="image" src="https://github.com/user-attachments/assets/f24b679d-fe82-4258-bc6c-0d730bfa9e5c" />
<br/>

<br/>

## ⚡Mediator (Arabulucu) Tasarım Deseni
<br/>
Diğer Adları: Intermediary, Controller
<br/>


---
## 🎯 Amaç (Intent)

Mediator, davranışsal (behavioral) bir tasarım desenidir.<br/>
Amaç: Nesneler arasındaki karmaşık bağımlılıkları azaltmak, doğrudan iletişimi engelleyip, tüm etkileşimi yalnızca bir arabulucu (mediator) nesne üzerinden gerçekleştirmektir.

---
<br/>

---

## ❓ Problem


Bir kullanıcı arayüzü (UI) düşünelim. Örneğin: müşteri profili oluşturma formu. Bu formda; textbox, checkbox, buton gibi farklı bileşenler vardır.<br/>

➵"Köpeğim var" kutucuğunu işaretleyince köpek ismi için ek bir alan açılması gerekebilir.<br/>
➵"Kaydet" butonuna tıklayınca, formdaki tüm alanların doğrulanması gerekebilir.<br/>

Bu durumda:

➵Bileşenler birbirine doğrudan bağımlı hale gelir.<br/>
➵Checkbox sınıfı, textbox’ı bilmek zorunda kalır.<br/>
➵Buton, bütün form elemanlarını kontrol etmek zorunda kalır.<br/>

👉 Sonuç: Kod yeniden kullanılabilirliğini kaybeder. Bir bileşeni başka yerde tek başına kullanmak zorlaşır.<br/>


<br/>


---


<br/>


---
## 💡 Çözüm 

Mediator deseni, doğrudan iletişimi ortadan kaldırır.<br/>

➵Her bileşen, yalnızca Mediator ile konuşur.<br/>
➵Mediator, hangi bileşenin nasıl tepki vereceğini belirler.<br/>
➵Bileşenler arasında gevşek bağlılık (loose coupling) sağlanır.<br/>

Örneğin:<br/>

➵"Kaydet" butonu sadece “Mediator’a haber ver” görevini yapar.<br/>
➵Mediator, formdaki diğer alanların doğrulanması gerektiğine karar verir ve onları tetikler.<br/>

Bu sayede, bileşenlerin tek tek bağımlılığı ortadan kalkar.<br/>
---

<br/>

---

##  🌍 Gerçek Dünya Örneği

Hava Trafik Kontrol Kulesi ✈️<br/>

a.Pilotlar doğrudan birbirleriyle konuşmaz.<br/>
a.Her pilot sadece kontrol kulesi ile iletişim kurar.<br/>
a.Kule, hangi uçağın önce ineceğine karar verir.<br/>

👉 Eğer pilotlar doğrudan birbirleriyle konuşsaydı, havaalanında kaos olurdu.<br/>
👉 Mediator, işte bu kule rolünü üstlenir.<br/>



---
<br/>

---

##  🏗 Yapı (Structure)

<b>1.Mediator Arayüzü<b/>

➵Bileşenlerin haberleşme yöntemlerini tanımlar.<br/>
➵Genellikle Notify veya Send gibi tek bir metot içerir.

<b>2.Concrete Mediator (Somut Arabulucu)<b/>

➵Bileşenler arasındaki iletişim kurallarını içerir.<br/>
➵Tüm bileşenlere referans tutabilir.

<b>3.Components (Bileşenler)<b/>

➵İş mantığını barındırır.<br/>
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
<img width="997" height="411" alt="image" src="https://github.com/user-attachments/assets/cae6ead1-83f7-4d89-a110-dc45165aabe9" />
<br/>


## 🌸 Template Method Tasarım Deseni
<br/>
Türü: Behavioral (Davranışsal)
<br/>


---
## 🎯 Amaç (Intent)

Template Method, bir algoritmanın iskeletini (sırasını) üst sınıfta tanımlar;<br/>
ancak algoritmanın belirli adımlarını alt sınıfların yeniden yazmasına (override) izin verir.<br/>

👉 Böylece algoritmanın genel akışı sabit kalır, ama alt sınıflar detayları özelleştirebilir.<br/>

---
<br/>

---

## ❓ Problem


Bir veri madenciliği uygulaması düşünelim:<br/>

➵Kullanıcı, uygulamaya farklı formatlarda belgeler (DOC, CSV, PDF) yükleyebiliyor.<br/>
➵Her format için farklı işleme kodu yazmanız gerekiyor.<br/>

Sorunlar:<br/>

1.Kod tekrarları oluşuyor: Açma, kapama, raporlama gibi adımlar hep aynı.<br/>
2.İstemci kodu karmaşıklaşıyor: Her format için ayrı koşul (if-else) kullanmak gerekiyor.<br/>

👉 Yani algoritma yapısı aynı, ama bazı adımlar formatlara göre değişiyor.<br/>




<br/>


---


<br/>


---
## 💡 Çözüm 

Template Method deseni öneriyor ki:<br/>

1.Algoritmayı adımlara ayır.<br/>
2.Bu adımları üst sınıfta tanımla.<br/>
3.Algoritmanın akışını bir template method içinde sırayla çalıştır.<br/>
4.Alt sınıflar, sadece kendilerine özel adımları override etsin.<br/>

Örneğin:

➵OpenFile() → Her format için farklı (abstract) <br/>
➵ExtractData() → Her format için farklı (abstract) <br/>
➵AnalyzeData() → Ortak, üst sınıfta (default implementation) <br/>
➵GenerateReport() → Ortak, üst sınıfta (default implementation) <br/>

📌 Böylece:

➵Genel algoritma akışı korunur.<br/>
➵Kod tekrarları ortadan kalkar.<br/>
➵İstemci, sadece üst sınıf tipini kullanarak (polymorphism) tüm alt sınıflarla çalışabilir..<br/>


---

<br/>

---

##  🌍 Gerçek Dünya Örneği



Toplu Konut İnşaatı 🏠<br/>

->Her evin temel iskeleti aynıdır (temel atma, duvar örme, tesisat).<br/>
->Ama bazı adımlar müşteriye göre değiştirilebilir (boya rengi, pencere tasarımı, iç mimari).<br/>

👉 Yani şablon aynı kalır, ama detaylar özelleştirilebilir.<br/>


---
<br/>

---

##  🏗 Yapı (Structure)



<b>Abstract Class (Soyut Sınıf)<b/>

a.Template method’u tanımlar.<br/>
a.Adım metotlarını (Step1, Step2 …) içerir.<br/>
a.Bazıları abstract (zorunlu), bazıları varsayılan (opsiyonel) olabilir.<br/>

<b>Concrete Class (Somut Sınıf)<b/>
b.Abstract adımları override eder.<br/>
b.İsterse varsayılanları da değiştirebilir.<br/>

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
<img width="581" height="224" alt="image" src="https://github.com/user-attachments/assets/fe47b693-50d5-4d3e-8b74-4a584f3484a6" />
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

Bir müşteri ve mağaza senaryosu düşünelim:<br/>

➵Müşteri, yeni bir ürünün (ör. iPhone) mağazaya gelip gelmediğini öğrenmek istiyor.<br/>

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

➵Observer deseni, publisher’a bir abonelik mekanizması ekler:<br/>
➵Aboneler listeye eklenebilir veya listeden çıkabilir.<br/>

Publisher’da bir olay olduğunda, listedeki tüm abonelere bildirim (update) gönderilir.<br/>

👉 Böylece:<br/>

➵İlgilenen aboneler bilgilendirilir.<br/>
➵Publisher, somut subscriber sınıflarını bilmez. Sadece onların interface’ini kullanır.<br/>


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

➵Aboneleri listeler.<br/>
➵Subscribe(), Unsubscribe(), Notify() metotlarını içerir.

<b>Subscriber (Abone)<b/>

➵Bildirim almak için Update() metodunu tanımlar.

<b>Concrete Subscriber<b/>

➵Bildirim geldiğinde belirli bir işlem yapar.

<b>Client<b/>

➵Publisher ve Subscriber nesnelerini oluşturur.<br/>
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
<img width="1019" height="436" alt="image" src="https://github.com/user-attachments/assets/e668145e-5c2a-49ac-b492-6748b0a9a5b2" />
<br/>
<img width="690" height="430" alt="image" src="https://github.com/user-attachments/assets/c3461662-6815-4da3-90b5-c7e61c6eeaa3" />
<br/>



## 🌻 Repository Design Pattern
<br/>
Also known as: Data Access Pattern
<br/>


---
## 🎯 Amaç (Intent)

Repository Design Pattern, veri erişim mantığını iş mantığından ayırarak uygulamayı daha düzenli, test edilebilir ve sürdürülebilir hale getirmeyi amaçlar.<br/>

Repository, uygulamanın veri katmanı ile domain/business katmanı arasında bir aracı (abstraction layer) görevi görür.

---
<br/>

---

## ❌ Problem

Bir uygulamada iş mantığı sınıflarının doğrudan veritabanı erişim kodlarıyla dolu olduğunu düşünelim.<br/>

Örneğin:<br/>

a.Bir CustomerService sınıfı hem müşteri ile ilgili iş mantığını hem de SQL sorgularını içeriyor.<br/>

Bu durumda:
<br/>
b.Kod okunabilirliği azalır.<br/>

b.Veri kaynağı değişirse (SQL → MongoDB, API vb.) her yerde değişiklik yapmak gerekir.<br/>

b.Test etmek zorlaşır çünkü gerçek veritabanına bağımlı hale gelir.<br/>


<br/>


---


<br/>


---
## 💡 Çözüm 


Repository Pattern, veri erişim işlemlerini kapsülleyen repository sınıfları oluşturmayı önerir.<br/>


➵ Repository, belirli bir entity için (Customer, Product, Order vb.) CRUD işlemlerini (Create, Read, Update, Delete) yapar.<br/>


➵ İş mantığı sınıfları repository üzerinden veriye erişir, SQL veya Entity Framework kodunu bilmez.<br/>


➵ Bu sayede uygulamanın veri erişim katmanı soyutlanır.<br/>

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

Bir şirketin sekreterini düşün.<br/>

a.Patron doğrudan herkesle iletişime geçmek yerine, sekretere söyler.<br/>

a.Sekreter (repository) patron adına işleri organize eder (arama, mesaj, randevu).<br/>

a.Patron işine (business logic) odaklanırken, sekreter de veri akışını yönetir.<br/>

Aynı şekilde repository de iş katmanı ile veri kaynağı arasında bir aracı görevi görür.<br/>

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
<img width="1002" height="174" alt="image" src="https://github.com/user-attachments/assets/fefbeebc-7a3b-4043-a387-f6737bb69a49" />
<br/>
<img width="430" height="498" alt="image" src="https://github.com/user-attachments/assets/e10337ef-c503-44c0-bf3d-ac3452245793" />
<br/>


## 🎣 Unit of Work Design Pattern
<br/>
Also known as: Transaction Script Manager
<br/>


---
## 🎯 Amaç (Intent)

Unit of Work, birden fazla repository ile yapılan işlemleri tek bir işlem (transaction) altında toplayarak:<br/>

Tüm değişikliklerin birlikte başarıyla kaydedilmesini<br/>

Veya tamamen geri alınmasını (rollback)<br/>

sağlar.

---
<br/>

---

## ❌ Problem

Bir e-ticaret uygulamasında:<br/>

Sipariş verildiğinde Orders tablosuna kayıt yapılır.<br/>

Aynı anda Stock tablosundan ürün düşülür.<br/>

Ayrıca Payments tablosuna ödeme bilgisi kaydedilir.<br/>

👉 Eğer bu işlemlerden biri başarısız olursa (ör. ödeme başarısız), diğer işlemler de geri alınmalıdır.<br/>
Repository’ler bağımsız çalıştığında veri tutarsızlığı oluşur.<br/>
<br/>


---


<br/>


---
## 💡 Çözüm 


Unit of Work tüm repository işlemlerini tek bir transaction altında toplar.<br/>

Begin Transaction → İşlemler başlar<br/>

➵ Repository’ler aracılığıyla entity değişiklikleri yapılır<br/>

➵ Commit() → Tüm değişiklikler veritabanına kaydedilir<br/>

➵ Rollback() → Hata durumunda tüm değişiklikler geri alınır<br/>







---

<br/>

---

##  🌍 Gerçek Dünya Örneği

Bir bankada para transferi:<br/>

Ali’nin hesabından para çekilir.<br/>

Veli’nin hesabına para yatırılır.<br/>

Eğer yatırma işlemi başarısız olursa, çekilen para geri yatırılır.<br/>
Bu işlemler tek bir transaction gibi çalışır.<br/>
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

<img width="1014" height="302" alt="image" src="https://github.com/user-attachments/assets/d97e128a-0ad1-4f80-b568-ab829d46b3c7" />

<br/>
<img width="465" height="368" alt="image" src="https://github.com/user-attachments/assets/929136e6-6eaf-4f08-9574-d0d2032fe60f" />
<br/>



## 🌳 Composite Design Pattern
<br/>
Also known as: Object Tree
<br/>


---
## 🎯 Amaç (Intent)

Composite, nesneleri ağaç yapıları halinde düzenlemenize ve bu yapılarla tekil nesneymiş gibi çalışmanıza olanak tanıyan bir structural design pattern’dir.<br/>

---
<br/>

---

## ❌ Problem

Bir sipariş sisteminiz olduğunu düşünün:<br/>

a.Product → Tek bir ürün (ör. Laptop).<br/>

a.Box → İçinde ürünler ve başka kutular olabilir.<br/>

👉 Müşteri siparişi verdiğinde, fiyatı hesaplamak için:<br/>

a.Kutuları açıp içindekileri dolaşmak<br/>

a.İç içe geçmiş kutuların seviyelerini bilmek<br/>

a.Farklı sınıflar (Product, Box) için ayrı mantık yazmak gerekir.<br/>

Bu, kodun karmaşık ve bakımı zor hale gelmesine yol açar.<br/>
<br/>


---


<br/>


---
## 💡 Çözüm 

Composite, hem Product hem de Box için ortak bir arayüz (IComponent) tanımlar.<br/>

➵Product (Leaf): Fiyatını direkt döndürür.<br/>

➵Box (Composite): İçindekileri dolaşır, fiyatlarını toplar ve kendi ek maliyetini (ör. paketleme ücreti) ekleyebilir.<br/>

👉 Böylece müşteri için fark etmez:<br/>
Bir ürün de olsa, bir kutu da olsa aynı arayüz ile işlem yapılır.<br/>





---

<br/>

---

##  🌍 Gerçek Dünya Örneği

Askeri hiyerarşi:<br/>

➵Ordu → Tümen → Tugay → Tabur → Takım → Asker<br/>

➵Emir en üstten en alta kadar aynı şekilde aktarılır.<br/>
Her seviye, altındaki tüm yapıyı yönetir.<br/>
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
<img width="568" height="152" alt="image" src="https://github.com/user-attachments/assets/bbc29920-4d40-4e45-b1be-24eb2deebff2" />
<br/>
<img width="683" height="246" alt="image" src="https://github.com/user-attachments/assets/cdedf04b-7f08-48b7-acbd-7e749e4e9c07" />
<br/>
<img width="419" height="467" alt="image" src="https://github.com/user-attachments/assets/cdf3485c-7480-4012-88c6-b532c0cf66ec" />
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

Koleksiyonlar yazılım geliştirmede en çok kullanılan veri yapılarındandır. Ancak:<br/>

a.Her koleksiyon elemanlarını farklı şekilde tutar (liste, yığın, ağaç, grafik).<br/>

a.Koleksiyonun elemanlarına erişmek için farklı yöntemler gerekir.<br/>

a.Bazen farklı gezinme algoritmaları (ör. derinlik öncelikli, genişlik öncelikli, rastgele erişim) gerekebilir.<br/>

Eğer tüm bu algoritmalar koleksiyonun içine eklenirse:<br/>

a.Koleksiyonun asıl amacı olan veri saklama bulanıklaşır.<br/>

a.Farklı koleksiyonlara erişmek için client kodu belirli koleksiyon sınıflarına bağımlı hale gelir.<br/>

---


<br/>


---
## 💡 Çözüm 

Iterator deseni, gezinme (traversal) davranışını koleksiyonun içinden ayırarak ayrı bir Iterator nesnesine taşır.<br/>

➵Iterator, gezinme algoritmasını kapsüller.<br/>

➵Koleksiyonun mevcut durumunu (current position, kalan eleman sayısı) kendi içinde tutar.<br/>

➵Bir koleksiyon için birden fazla iterator aynı anda bağımsız olarak çalışabilir.<br/>

➵Tüm iterator’lar aynı arayüzü (interface) uygular → Böylece client kodu, koleksiyon tipinden bağımsız olur.<br/>

👉 Yeni bir gezinme algoritması gerektiğinde sadece yeni bir Iterator sınıfı yazılır; koleksiyon veya client değiştirilmez.<br/>



---

<br/>

---

##  🌍 Gerçek Dünya Örneği

Roma’da gezilecek yerler koleksiyonunu düşün:<br/>

b.Kendi başına gezinmek → kontrolsüz ve zaman kaybettirir.<br/>

b.Telefon navigasyonu → ucuz ve pratik bir iterator.<br/>

b.Yerel rehber → daha pahalı ama özel, kişiselleştirilmiş bir iterator.<br/>

Her biri aynı koleksiyonu (Roma’daki tarihi yerler) farklı şekilde gezme algoritmasıyla temsil eder.<br/>
---
<br/>

---

##  🏗 Yapı (Structure)


1.Iterator (Arayüz) → Gezinti için gerekli metotları tanımlar (Next(), HasNext() vb.).<br/>

2.ConcreteIterator → Belirli bir gezinme algoritmasını uygular, mevcut pozisyonu takip eder.<br/>

3.Collection (Arayüz) → Uyumlu iterator döndüren metotları tanımlar.<br/>

4.ConcreteCollection → Belirli bir ConcreteIterator döndürür.<br/>

5.Client → Koleksiyon ve iterator ile sadece arayüzler üzerinden çalışır.<br/>

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
<img width="966" height="252" alt="image" src="https://github.com/user-attachments/assets/3079ae4d-57cf-4df3-a30a-d8997c4e2a28" />
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

Bir uygulamanın karmaşık bir kütüphane veya framework ile çalışması gerektiğini düşünelim.<br/>

a.Birçok nesnenin doğru sırada başlatılması,<br/>

a.Bağımlılıkların takip edilmesi,<br/>

a.Metotların uygun sırayla çağrılması gerekir.<br/>

Bu durumda:<br/>

b.İş mantığı, üçüncü parti sınıfların uygulama detaylarına sıkı sıkıya bağımlı hale gelir.<br/>

b.Kod zor anlaşılır ve bakımı zor olur.<br/>

---


<br/>


---
## 💡 Çözüm 

Facade deseni, bu karmaşık sistemi saran basit bir ara yüz sınıfı sağlar.<br/>

Facade, alt sistemin karmaşıklığını gizler.<br/>

Kullanıcıya yalnızca gerekli olan metotları sunar.<br/>

Gereksiz detayları dışarı sızdırmaz.<br/>

Örneğin:<br/>
Bir uygulama profesyonel bir video dönüştürme kütüphanesi kullanıyor olabilir.<br/>
Ama uygulamanın ihtiyacı yalnızca:<br/>

```bash
videoFacade.Encode("cat.mp4", "mp4");

```


---

<br/>

---

##  🌍 Gerçek Dünya Örneği

Telefonla sipariş verdiğinizi düşünün:<br/>

a.Operatör, sizin için Facade görevi görür.<br/>

a.Sipariş sistemine, ödeme altyapısına ve kargoya erişim sağlar.<br/>

a.Siz yalnızca bir numara arayıp sipariş verirsiniz → karmaşık süreçleri bilmenize gerek yoktur.<br/>
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
<img width="1031" height="335" alt="image" src="https://github.com/user-attachments/assets/a3769306-0d14-41d5-b755-a0b927c54eb8" />
<br/>
<img width="715" height="170" alt="image" src="https://github.com/user-attachments/assets/7870e13b-0dbf-441e-80f8-5872bdaa3eaa" />
<br/>
<img width="484" height="116" alt="image" src="https://github.com/user-attachments/assets/ef424d3e-d6f7-4be8-84a1-d2204983a27b" />
<br/>
<img width="1024" height="395" alt="image" src="https://github.com/user-attachments/assets/fdb16a39-ac81-4ae0-a529-1465173406eb" />
<br/>
<img width="728" height="168" alt="image" src="https://github.com/user-attachments/assets/28a0209f-9261-4b55-b68d-f9cc9c14fe5a" />
<br/>


## 🎭 Decorator Design Pattern
<br/>

<br/>


---
## 🎯 Amaç (Intent)

Decorator, bir structural (yapısal) tasarım deseni olup, nesnelere yeni davranışlar eklemenin bir yolunu sunar.<br/>
Bunu, nesneleri aynı arayüzü uygulayan özel “sarmalayıcı” (wrapper) nesneler içine alarak yapar.

---
<br/>

---

## ❌ Problem

Bir bildirim (notification) kütüphanesi geliştirdiğinizi düşünün.<br/>
Başta sadece e-posta bildirimi gönderen Notifier sınıfınız var.<br/>

Daha sonra:<br/>

a.Kullanıcılar SMS bildirimi istiyor.<br/>

a.Bazıları Facebook bildirimi istiyor.<br/>

a.Kurumsal kullanıcılar ise Slack bildirimi talep ediyor.<br/>

👉 İlk çözüm: Notifier sınıfını miras alıp her biri için alt sınıflar (subclass) oluşturmak.<br/>
Ama sorun şu:<br/>

b.Birden fazla bildirim türü aynı anda kullanılamıyor.<br/>

b.Tüm kombinasyonları oluşturmak için çok fazla alt sınıf gerekir (sınıf patlaması / combinatorial explosion).<br/>

---


<br/>


---
## 💡 Çözüm 

Decorator deseni ile:<br/>

a.Her bildirim türü için bir decorator sınıfı oluşturulur.<br/>

a.Tüm sınıflar aynı INotifier arayüzünü uygular.<br/>

a.Bir Notifier nesnesi, birden fazla decorator ile sarılabilir.<br/>

## 🔑 Özet:

b.EmailNotifier → Temel bildirim.<br/>

b.SMSDecorator, SlackDecorator, FacebookDecorator → Ek özellikleri dinamik olarak ekler.<br/>

b.Decorator’lar birbirine zincirleme eklenebilir (stack).<br/>

---

<br/>

---

##  🌍 Gerçek Dünya Örneği

Kıyafet giymek 🎽🧥🌧️:<br/>

a.Önce tişört giyersiniz (temel nesne).<br/>

a.Üşüyünce kazak giyersiniz (decorator).<br/>

a.Daha çok üşüyünce mont eklersiniz (decorator).<br/>

a.Yağmur yağarsa yağmurluk giyersiniz (decorator).<br/>

👉 İhtiyaca göre katmanlı bir şekilde özellik eklenir, ve istenildiğinde kolayca çıkarılabilir.<br/>
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
<img width="1024" height="424" alt="image" src="https://github.com/user-attachments/assets/b4169038-bb24-46d7-b929-4029b1242284" />
<br/>
<img width="670" height="201" alt="image" src="https://github.com/user-attachments/assets/dd6ec8bd-d7e3-4fea-828a-686e58bcd751" />
<br/>
<img width="1041" height="449" alt="image" src="https://github.com/user-attachments/assets/d0a1a756-1020-42e1-acc1-2906f7ccab97" />
<br/>
<img width="628" height="191" alt="image" src="https://github.com/user-attachments/assets/ebbbf9d7-97c0-458b-912a-557554c2f2de" />
<br/>
<img width="1035" height="471" alt="image" src="https://github.com/user-attachments/assets/8afce0b1-09ab-48a5-ba09-272d2fe91971" />
<br/>
<img width="626" height="197" alt="image" src="https://github.com/user-attachments/assets/3193fe6c-8796-4f26-a1be-464f987be68e" />
<br/>
<img width="1046" height="455" alt="image" src="https://github.com/user-attachments/assets/84a6f1ea-cfec-4511-a3ae-ee9ead8d6a3f" />
<br/>
<img width="686" height="195" alt="image" src="https://github.com/user-attachments/assets/ef443021-d6ef-4043-9236-f9ecadd5a464" />
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

