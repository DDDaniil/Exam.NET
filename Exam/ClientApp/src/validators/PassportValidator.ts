import {
    AdultMax,
    AdultMin,
    AmountMax,
    AmountMin,
    CarAgeMax,
    CarAgeMin,
    NameMaxLength,
    NameMinLength,
    PassportIssuerMaxLength,
    PassportIssuerMinLength,
    PassportNumberLength,
    PassportRegInformationMaxLength,
    PassportRegInformationMinLength,
    PassportSeriesLength,
    PatronymicMaxLength,
    PatronymicMinLength,
    SurnameMaxLength,
    SurnameMinLength
} from "../variables/Variables";

export const IsPassportSeriesValid = (value: string) =>
    value.length === PassportSeriesLength;
export const IsPassportNumberValid = (value: string) =>
    value.length === PassportNumberLength;
export const IsPassportIssuerValid = (value: string) =>
    PassportIssuerMinLength <= value.length && value.length <= PassportIssuerMaxLength;
export const IsPassportRegInformationValid = (value: string) =>
    PassportRegInformationMinLength <= value.length && value.length <= PassportRegInformationMaxLength;