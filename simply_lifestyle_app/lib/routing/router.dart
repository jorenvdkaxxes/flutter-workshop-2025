import 'package:flutter/material.dart';
import 'package:go_router/go_router.dart';
import 'package:provider/provider.dart';
import 'package:simply_lifestyle_app/data/repositories/auth/auth_repository.dart';
import 'package:simply_lifestyle_app/main.dart';
import 'package:simply_lifestyle_app/ui/auth/login/view_models/login_viewmodel.dart';
import 'package:simply_lifestyle_app/ui/auth/login/widgets/login_screen.dart';
import 'package:simply_lifestyle_app/ui/orders/view_model/new_order_view_model.dart';
import 'package:simply_lifestyle_app/ui/orders/widgets/new_order/new_order_screen.dart';
import 'package:simply_lifestyle_app/ui/products/view_model/product_detail_view_model.dart';
import 'package:simply_lifestyle_app/ui/products/widgets/product_details_page.dart';

import 'routes.dart';

GoRouter router(
  AuthRepository authRepository,
) => GoRouter(
      initialLocation: Routes.home,
      debugLogDiagnostics: true,
      redirect: _redirect,
      routes: [
        GoRoute(
          path: Routes.login,
          builder: (context, state) {
            return LoginScreen(
              viewModel: LoginViewModel(
                authRepository: context.read(),
              ),
            );
          },
        ),
        GoRoute(
        path: Routes.home,
        builder: (context, state) => HomePage(),
          routes: [
            // Product Details
            GoRoute(
              path: Routes.productDetails,
              builder: (context, state) {
                final id = state.pathParameters['id']!;
                final viewModel =
                    ProductDetailViewModel(productsRepository: context.read());

                // When opening the product details screen with an existing id
                // load and display that product.
                viewModel.loadProduct.execute(id);
                return ProductDetailsPage(viewModel: viewModel);
              },
            ),
            // New Order
            GoRoute(
              path: Routes.newOrder,
              builder: (context, state) {
                final viewModel = NewOrderViewModel(
                    productsRepository: context.read(),
                    ordersRepository: context.read());
                return NewOrderScreen(viewModel: viewModel);
              },
            ),
          ],
        ),
      ],
    );

Future<String?> _redirect(BuildContext context, GoRouterState state) async {
  // if the user is not logged in, they need to login
  final loggedIn = await context.read<AuthRepository>().isAuthenticated;
  final loggingIn = state.matchedLocation == Routes.login;
  if (!loggedIn) {
    return Routes.login;
  }

  // if the user is logged in but still on the login page, send them to
  // the home page
  if (loggingIn) {
    return Routes.home;
  }

  // no need to redirect at all
  return null;
}
