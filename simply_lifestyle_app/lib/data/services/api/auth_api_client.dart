// Copyright 2024 The Flutter team. All rights reserved.
// Use of this source code is governed by a BSD-style license that can be
// found in the LICENSE file.

import 'dart:convert';
import 'dart:io';

import 'package:simply_lifestyle_app/environment.dart';

import '../../../utils/result.dart';
import 'model/login_request/login_request.dart';
import 'model/login_response/login_response.dart';

class AuthApiClient {
  AuthApiClient({
    HttpClient Function()? clientFactory,
  }) : _clientFactory = clientFactory ?? HttpClient.new;

  final String _host = Environment.restApiHost;
  final int _port = Environment.restApiPort;
  final HttpClient Function() _clientFactory;

  Future<Result<LoginResponse>> login(LoginRequest loginRequest) async {
    final client = _clientFactory();
    try {
      final request = await client
          .postUrl(Uri.parse('https://$_host:$_port/api/identity/login'));
          
      var content = jsonEncode(loginRequest);
      request.headers.contentType = ContentType.json;
      request.headers.contentLength = content.length;

      request.write(content);
      final response = await request.close();
      if (response.statusCode == 200) {
        final stringData = await response.transform(utf8.decoder).join();
        return Result.ok(LoginResponse.fromJson(jsonDecode(stringData)));
      } else {
        return const Result.error(HttpException("Login error"));
      }
    } on Exception catch (error) {
      return Result.error(error);
    } finally {
      client.close();
    }
  }
}
