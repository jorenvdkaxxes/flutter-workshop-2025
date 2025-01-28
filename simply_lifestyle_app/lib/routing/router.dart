import 'package:go_router/go_router.dart';
import 'package:provider/provider.dart';
import 'package:simply_lifestyle_app/main.dart';
import 'package:simply_lifestyle_app/ui/orders/view_model/new_order_view_model.dart';
import 'package:simply_lifestyle_app/ui/orders/widgets/new_order/new_order_screen.dart';
import 'package:simply_lifestyle_app/ui/products/view_model/product_detail_view_model.dart';
import 'package:simply_lifestyle_app/ui/products/widgets/product_details_page.dart';

import 'routes.dart';

GoRouter router() => GoRouter(
      initialLocation: Routes.home,
      debugLogDiagnostics: true,
      routes: [
        GoRoute(
          path: Routes.home,
          builder: (context, state) {
            return MyHomePage();
          },
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
                final viewModel =
                    NewOrderViewModel(productsRepository: context.read());
                return NewOrderScreen(viewModel: viewModel);
              },
            ),
          ],
        ),
      ],
    );
