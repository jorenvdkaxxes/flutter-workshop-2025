// Copyright 2024 The Flutter team. All rights reserved.
// Use of this source code is governed by a BSD-style license that can be
// found in the LICENSE file.

abstract final class Routes {
  static const home = '/';
  static const products = '/products';
  static const newOrder = '/new-order';
  static const productDetails = '$products/:id';
  static String productsWithId(String id) => '$products/$id';
}
