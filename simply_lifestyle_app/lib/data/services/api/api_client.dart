import 'dart:convert';
import 'dart:io';

import 'package:simply_lifestyle_app/domain/models/product/product.dart';
import 'package:simply_lifestyle_app/environment.dart';
import 'package:simply_lifestyle_app/utils/result.dart';

class ApiClient {
  ApiClient({
    HttpClient Function()? clientFactory,
  })  : _clientFactory = clientFactory ?? HttpClient.new;

  final String _host = Environment.restApiHost;
  final int _port = Environment.restApiPort;
  final HttpClient Function() _clientFactory;

  Future<Result<List<Product>>> getProducts() async {
    final client = _clientFactory();
    try {
      final request = await client.getUrl(Uri.parse('https://$_host:$_port/api/Products/Get'));
      // final request = await client.get(_host, _port, '/continent'); // When using HTTP
      final response = await request.close();
      if (response.statusCode == 200) {
        final stringData = await response.transform(utf8.decoder).join();
        final json = jsonDecode(stringData) as List<dynamic>;
        return Result.ok(
            json.map((element) => Product.fromJson(element)).toList());
      } else {
        return const Result.error(HttpException("Invalid response"));
      }
    } on Exception catch (error) {
      return Result.error(error);
    } finally {
      client.close();
    }
  }
}
