using System;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


// az login でログインしておき、ログインするアカウントに kv の権限をつけておくこと
// export KEY_VAULT_NAME="taktest" で環境変数を作っておくこと
string keyVaultName = Environment.GetEnvironmentVariable("KEY_VAULT_NAME");
var kvUri = "https://" + keyVaultName + ".vault.azure.net";

var client = new SecretClient(new Uri(kvUri), new DefaultAzureCredential());

// 取得したいシークレット名前
string secretName = "taktest2";

Console.WriteLine($"Retrieving your secret from {keyVaultName}.");
var secret = await client.GetSecretAsync(secretName);
Console.WriteLine($"Your secret is '{secret.Value.Value}'.");
