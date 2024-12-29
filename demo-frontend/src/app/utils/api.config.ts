import {InjectionToken, Provider} from '@angular/core';
import {environment} from '../../environments/environment';

export const API_BASE_URL = new InjectionToken<string>('API_BASE_URL');

export type ApiUrlBuilder = (path: string) => string;
export const API_URL_BUILDER = new InjectionToken<ApiUrlBuilder>('API_URL_BUILDER');

function constructApiUrlBuilder(): ApiUrlBuilder {
  return (path: string) => {
    return new URL(path, environment.apiBaseUrl).toString();
  };
}

export const provideApiBaseUrl = (): Provider[] => {
  return [
    {provide: API_BASE_URL, useValue: environment.apiBaseUrl},
    {provide: API_URL_BUILDER, useValue: constructApiUrlBuilder()}
  ];
}
