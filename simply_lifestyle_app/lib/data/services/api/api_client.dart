import 'dart:convert';
import 'dart:io';

import 'package:simply_lifestyle_app/data/services/api/model/order/order_api_model.dart';
import 'package:simply_lifestyle_app/data/services/api/model/order/order_created_api_model.dart';
import 'package:simply_lifestyle_app/data/services/api/model/order/order_post_api_model.dart';
import 'package:simply_lifestyle_app/domain/models/product/product.dart';
import 'package:simply_lifestyle_app/environment.dart';
import 'package:simply_lifestyle_app/utils/result.dart';

typedef AuthHeaderProvider = String? Function();

class ApiClient {
  ApiClient({
    HttpClient Function()? clientFactory,
  }) : _clientFactory = clientFactory ?? HttpClient.new;

  final String _host = Environment.restApiHost;
  final int _port = Environment.restApiPort;
  final HttpClient Function() _clientFactory;

  AuthHeaderProvider? _authHeaderProvider;

  set authHeaderProvider(AuthHeaderProvider authHeaderProvider) {
    _authHeaderProvider = authHeaderProvider;
  }

  Future<void> _authHeader(HttpHeaders headers) async {
    final header = _authHeaderProvider?.call();
    if (header != null) {
      headers.add(HttpHeaders.authorizationHeader, header);
    }
  }

  Future<Result<List<Product>>> getProducts() async {
    final client = _clientFactory();
    try {
      final request = await client
          .getUrl(Uri.parse('https://$_host:$_port/api/Products/Get'));
      // final request = await client.get(_host, _port, '/continent'); // When using HTTP
      await _authHeader(request.headers);
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

  Future<Result<Product>> getProductById(String id) async {
    final client = _clientFactory();
    try {
      final request = await client
          .getUrl(Uri.parse('https://$_host:$_port/api/Products/GetById/$id'));
      // final request = await client.get(_host, _port, '/continent'); // When using HTTP
      final response = await request.close();
      if (response.statusCode == 200) {
        final stringData = await response.transform(utf8.decoder).join();
        final json = jsonDecode(stringData) as dynamic;
        return Result.ok(Product.fromJson(json));
      } else {
        return const Result.error(HttpException("Invalid response"));
      }
    } on Exception catch (error) {
      return Result.error(error);
    } finally {
      client.close();
    }
  }

  Future<Result<List<OrderApiModel>>> getOrders() async {
    final client = _clientFactory();
    try {
      final request = await client
          .getUrl(Uri.parse('https://$_host:$_port/api/orders/get'));
      // final request = await client.get(_host, _port, '/continent'); // When using HTTP
      final response = await request.close();
      if (response.statusCode == 200) {
        final stringData = await response.transform(utf8.decoder).join();
        final json = jsonDecode(stringData) as List<dynamic>;
        return Result.ok(
            json.map((element) => OrderApiModel.fromJson(element)).toList());
      } else {
        return const Result.error(HttpException("Invalid response"));
      }
    } on Exception catch (error) {
      return Result.error(error);
    } finally {
      client.close();
    }
  }

  Future<Result<OrderCreatedApiModel>> postOrder(OrderPostApiModel order) async {
    final client = _clientFactory();
    try {
      final request = await client
          .postUrl(Uri.parse('https://$_host:$_port/api/orders/create'));
      request.headers.contentType = ContentType.json;
      request.write(jsonEncode(order));
      final response = await request.close();
      if (response.statusCode == 200) {
        final stringData = await response.transform(utf8.decoder).join();
        final orderCreated = OrderCreatedApiModel.fromJson(jsonDecode(stringData));
        return Result.ok(orderCreated);
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
