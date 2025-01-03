import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'package:simply_lifestyle_app/models/product/product.dart';
import 'package:simply_lifestyle_app/pages/products_page/product_details_page/product_details_page.dart';

class ProductsPage extends StatefulWidget {
  const ProductsPage({super.key});

  @override
  State<ProductsPage> createState() => _ProductsPageState();
}

class _ProductsPageState extends State<ProductsPage> {
  late Future<List<Product>> futureProducts;
  final List<String> items = List<String>.generate(5, (i) => 'Product $i');

  @override
  void initState() {
    super.initState();
    futureProducts = fetchProducts();
  }

  Future<List<Product>> fetchProducts() async {
    final response =
        await http.get(Uri.parse('https://localhost:7190/api/Products/Get'));

    if (response.statusCode == 200) {
      Iterable l = json.decode(response.body);
      return List<Product>.from(l.map((model) => Product.fromJson(model)));
    } else {
      throw Exception('Failed to products album');
    }
  }

  @override
  Widget build(BuildContext context) {
    return FutureBuilder<List<Product>>(
        future: futureProducts,
        builder: (context, products) {
          if (!products.hasData && products.error == null) {
            return CircularProgressIndicator();
          } else if (!products.hasData && products.error != null) {
            return Center(
              child: Column(
                mainAxisAlignment: MainAxisAlignment.center,
                children: [
                  Text(
                    "Something went wrong.",
                    style: TextStyle(fontSize: 20),
                  ),
                  Text("Could not get the products.",
                      style: TextStyle(fontSize: 20)),
                ],
              ),
            );
          }
          return ListView.builder(
            itemCount: products.data!.length,
            prototypeItem: ListTile(
              title: Text(products.data!.first.name),
            ),
            itemBuilder: (context, index) {
              return ListTile(
                title: Text(products.data![index].name),
                subtitle: Text('Stock: ${products.data![index].stock}'),
                onTap: () {
                  Navigator.push(
                    context,
                    MaterialPageRoute(
                      builder: (context) => const ProductDetailsPage(),
                      settings: RouteSettings(
                        arguments: products.data![index],
                      ),
                    ),
                  );
                },
              );
            },
          );
        });
  }
}
