open System
open System.Security.Cryptography
open System.Text

[<assembly: ArmDot.Client.ObfuscateNames()>]
[<assembly: ArmDot.Client.ObfuscateControlFlowAttribute()>]
[<assembly: ArmDot.Client.VirtualizeCodeAttribute()>]

do()

[<ArmDot.Client.ObfuscateNames()>]
let sha256 (data : byte array) : string =
    use sha256 = SHA256.Create()
    (StringBuilder(), sha256.ComputeHash(data))
    ||> Array.fold (fun sb b -> sb.Append(b.ToString("x2")))
    |> string

[<ArmDot.Client.ObfuscateNames()>]
let checkPassword (text: string) : bool =
    let bytes = Encoding.UTF8.GetBytes text
    let hash = sha256 bytes
    hash.Equals "9997ee6bc0524093f7dfb2ae8f80a997d75504bfd2e829f54a2a0cd3172adad8"

[<ArmDot.Client.ObfuscateNames()>]
[<EntryPoint>]
let main argv =
    let password = Console.ReadLine()
    let correct = checkPassword password
    if correct
    then printfn "correct"
    else printfn "wrong"
    0 // return an integer exit code
