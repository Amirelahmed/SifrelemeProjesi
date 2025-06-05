🔐 Şifreleme Projesi
SifrelemeProjesi, ASP.NET Core MVC 8 framework'ü kullanılarak geliştirilmiş bir web uygulamasıdır. Bu uygulama, kullanıcıların metin veya dosya verilerini güvenli bir şekilde şifrelemelerine ve çözmelerine olanak tanır. Projede iki ana kriptografi yöntemi kullanılmıştır:

.RSA (Rivest–Shamir–Adleman) Şifreleme: Asimetrik bir şifreleme algoritmasıdır. Kullanıcılar, verilerini bir açık anahtar ile şifreleyebilir ve sadece ilgili özel anahtar ile çözebilirler. Bu yöntem, özellikle güvenli veri iletimi için idealdir.

.SHA256 (Secure Hash Algorithm 256-bit): Tek yönlü bir hash algoritmasıdır. Verilerin sabit uzunlukta bir özetini oluşturur. Bu özet, veri bütünlüğünü kontrol etmek veya parolaları güvenli bir şekilde saklamak için kullanılır.

Uygulama, kullanıcı dostu bir arayüz ile bu işlemleri gerçekleştirmeyi sağlar. Ayrıca, projenin canlı demosuna [buradan](http://publishsifreleme.somee.com/) ulaşabilirsiniz.

🖼️ Kullanıcı Arayüzü Görselleri ve Açıklamaları

1. Anasayfa

![image alt](https://github.com/user-attachments/assets/d0d72660-cd6e-4d60-abce-d1060fac5db8)

RSA şifreleme, RSA çözme ve SHA256 hash işlemleri için ilgili sayfalara yönlendirilir. Arayüz, kullanıcı dostu bir navigasyon sunar.

2. RSA Şifreleme Sayfası

![image alt](https://github.com/user-attachments/assets/cf6e6e80-392d-46a9-8e2f-3570bdc4d02d)

Yukardaki metin verilerini girerek RSA algoritması ile şifreleyebilirler. Şifreleme işlemi sonucunda, şifrelenmiş metin kullanıcıya sunulur. Ayrıca, kullanılan açık anahtar bilgisi de görüntülenebilir.

3. RSA Çözme Sayfası

![image alt](https://github.com/user-attachments/assets/21e709c6-3105-4fe7-b386-6faf04c5ebbb)

Yukardaki, RSA ile şifrelenmiş verilerin çözülmesini sağlar. Kullanıcı, şifrelenmiş metni ve ilgili özel anahtarı girerek orijinal veriye ulaşabilir.

4. SHA256 Hash Sayfası

SHA256 algoritması ile metin verisinin hash değeri oluşturulur. Bu hash, parola gibi verilerin güvenli bir biçimde tutulmasında kullanılır.

5. Dosya Seçme SHA256 Hash

![image alt](https://github.com/user-attachments/assets/37c9e897-625e-4f1f-88e9-eafc0f41058c)

Yukardaki, kullanıcıların bilgisayarlarından bir dosya seçerek SHA256 hash değerini oluşturmalarını sağlar. Dosya bütünlüğünü kontrol etmek için kullanışlıdır.

6. Dosya Şifreleme SHA256 Hash

![image alt](https://github.com/user-attachments/assets/8d487021-6f40-4396-8726-0b82ad5228bd)

Kullanıcılar, seçtikleri dosyaların SHA256 hash değerini oluşturabilirler. Bu işlem, dosya bütünlüğünü sağlamak ve veri değişikliklerini tespit etmek için önemlidir.

7. Metin Şifreleme SHA256 Hash

![image alt](https://github.com/user-attachments/assets/f1291c95-e117-41a5-9806-c9bb687b8eb7)

Yukardaki, kullanıcıların düz metin verilerini SHA256 algoritması ile hash’lemesini sağlar. Kullanıcı metni girdikten sonra sistem, SHA256 algoritmasını çalıştırarak bu metne karşılık gelen sabit uzunlukta hash değeri üretir. Bu özellik genellikle parola gibi hassas bilgileri geri döndürülemez bir biçimde güvenli şekilde saklamak amacıyla kullanılır.

⚙️ Özellikler
🛡️ RSA Şifreleme ve Çözme: Metin verilerini RSA algoritması ile şifreleme ve çözme işlemleri.

🔐 SHA256 Hash Oluşturma: Metin ve dosya verileri için SHA256 hash değeri oluşturma.

📄 Dosya İşlemleri: Kullanıcıların dosya seçerek hash değerlerini oluşturabilmeleri.

🎨 Kullanıcı Dostu Arayüz: Basit ve anlaşılır bir kullanıcı arayüzü ile kolay kullanım.

🌐 Canlı Demo: Uygulamanın canlı demosuna erişim imkanı.

💻 Kullanılan Teknolojiler
ASP.NET Core MVC 8: Web uygulaması geliştirme framework'ü.

C#: Uygulama geliştirme dili.

RSA Algoritması: Asimetrik şifreleme yöntemi.

SHA256 Algoritması: Tek yönlü hash algoritması.

HTML/CSS/JavaScript: Ön yüz tasarımı ve etkileşimleri.

Somee.com: Uygulamanın barındırıldığı platform.
