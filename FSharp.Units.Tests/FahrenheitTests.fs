﻿namespace FSharp.Units.Tests

module FarenheitTests =

    open System
    open Xunit
    open FsCheck
    open FsCheck.Xunit
    open FsUnit
    open FsUnit.Xunit
    open FSharp.Units
    open FSharp.Units.Temperature
    open Helpers

   // fahrenheit to X and back

    [<Property>]
    let ``From fahrenheit to celsius and back`` () =
        let property value = 
            let celsius = F.toCelsius (F.create value)
            let fahrenheit = C.toFahrenheit celsius

            fahrenheit
            |> should (equalWithin 0.1) value

        Check.QuickThrowOnFailure (testRange property)

    [<Property>]
    let ``From fahrenheit to kelvin and back`` () =
        let property value = 
            let kelvin = F.toKelvin (F.create value)
            let fahrenheit = K.toFahrenheit kelvin

            fahrenheit
            |> should (equalWithin 0.1) value

        Check.QuickThrowOnFailure (testRange property)

    [<Fact>]
    let ``Convert known fahrenheit to kelvin`` () =
        let kelvin = F.toKelvin 123.<F>

        kelvin
        |> should (equalWithin 0.1) 323.706<C>

