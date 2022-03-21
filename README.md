# ShopCheck
## Proje Detayları
- Uygulamamız herhangi bir mağazada yapılan satışların tutulduğu ve yönetildiği bir uygulamadır.
- Müşteri bilgileri, ürün bilgileri, taksit seçenekleri ve yapılan satış bilgilerini database üzerinde tutar.
- Proje databasesini __Sql Server__ oluşturur. 
- SQL Server bağlantısı __Dapper__ ile gerçekleşir.
- Uygulamanın backendi __Katmanlı Mimari__ ile yazılmıştır.
- __SOLID__ ilkelerine bağlı kalınmıştır.
- __Dependency Injection__ ile database verilerine __API__ uygulamamız ulaşır.
- __CRUD__ işlemleri yapılabilen bir uygulamadır.
- Backend için __C#__ dili, frontend için __JavaScript__ dili kullanılmıştır.
- Uygulamamızda 3 sayfa bulunmaktadır. Bu sayfalar arasında buton ile geçiş sağlanır.

## Müşteriler Sayfası
- Bu sayfada database üzerine müşteri eklemesi yapılır.
- Müşteriler databaseden alınıp sayfamızda listelenir.
- Müşteri bilgilerinde değişiklik veya müşterileri silme gibi özellikler uygulanır.
- Ayrıca QueryString ile müşterinin idsi alınır ve satış sayfasında alışveriş yaptırılabilir.
- Sayfa resmi:

![CustomerPage](https://github.com/devmutluhan/ShopCheck/blob/main/images/M%C3%BC%C5%9Fteriler.png)

## Ürünler Sayfası
- Bu sayfada database üzerine ürün eklemesi yapılır.
- Ürün bilgileri databaseden alınıp sayfamızda listelenir.
- Satış yapıldıkça ürünün stok bilgisinde artma veya azalmalar yaşanır.
- Ayrıca sayfada ürün bilgileri üzerinde değişiklik veya ürünü tamamen kaldırma gibi özellikler bulunur.
- Sayfa resmi:

![ProductPage](https://github.com/devmutluhan/ShopCheck/blob/main/images/%C3%9Cr%C3%BCnler.png)

## Satışlar Sayfası
- Bu sayfada database üzerine satış bilgileri eklenir.
- Satış bilgileri databaseden alınıp sayfamızda listelenir.
- Ürün isimleri ve taksit seçenekleri sayfamızda select taginin içinde listelerinir.
- Buradan ürün ve taksit seçerek satış eklemesi yapabiliriz.
- Tabi her taksit seçeneğine bağlı komisyon ödemesi ile toplam fiyat hesaplanır ve listelenir.
- Ayrıca sayfada satış bilgilerini değiştirebilir veya satış işlemini tamamen kaldırabiliriz.
- Sayfa resmi:

![SalesPage](https://github.com/devmutluhan/ShopCheck/blob/main/images/Sat%C4%B1%C5%9Flar.png)
