abstract final class Routes {
  static const home = '/';
  static const login = '/login';
  static const products = '/products';
  static const newOrder = '/new-order';
  static const productDetails = '$products/:id';
  static String productsWithId(String id) => '$products/$id';
}
