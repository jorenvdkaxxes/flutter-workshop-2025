
import 'package:provider/provider.dart';
import 'package:provider/single_child_widget.dart';
import 'package:simply_lifestyle_app/data/repositories/products/products_repository.dart';
import 'package:simply_lifestyle_app/data/repositories/products/products_repository_local.dart';
import 'package:simply_lifestyle_app/data/repositories/products/products_repository_remote.dart';
import 'package:simply_lifestyle_app/data/services/local/local_data_service.dart';

import '../data/services/api/api_client.dart';

/// Configure dependencies for remote data.
/// This dependency list uses repositories that connect to a remote server.
List<SingleChildWidget> get providersRemote {
  return [
    Provider(
      create: (context) => ApiClient(),
    ),
    Provider(
      create: (context) => ProductsRepositoryRemote(
        apiClient: context.read(),
      ) as ProductsRepository,
    )
  ];
}

/// Configure dependencies for local data.
/// This dependency list uses repositories that provide local data.
/// The user is always logged in.
List<SingleChildWidget> get providersLocal {
  return [
    Provider.value(
      value: LocalDataService(),
    ),
    Provider(
      create: (context) => ProductsRepositoryLocal(
        localDataService: context.read(),
      ) as ProductsRepository,
    ),
  ];
}
