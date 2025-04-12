class LoginResponse {
  LoginResponse({required this.token});

  final String token;

  factory LoginResponse.fromJson(Map<String, Object?> json) {
    return switch (json) {
      {'token': String token} => LoginResponse(token: token),
      _ => throw const FormatException('Failed to load login response.'),
    };
  }
}
