import 'package:simply_lifestyle_app/domain/models/product/price.dart';
import 'package:simply_lifestyle_app/domain/models/product/product.dart';
import 'package:simply_lifestyle_app/domain/models/product/product_type.dart';

class LocalDataService {
  List<Product> getProducts() {
    return [
      Product(
          id: '7a8176bd-dcdb-4e56-9535-369fb360bf15',
          name: "Test-Product",
          description: "Test-Description",
          productType: ProductType.kaliSeats,
          price: Price(amount: 1000, currency: "Eur"),
          stock: 5),
    ];
  }
}
