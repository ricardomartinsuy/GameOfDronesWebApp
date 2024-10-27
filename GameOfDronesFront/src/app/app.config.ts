import { ApplicationConfig } from '@angular/core';
import { provideRouter } from '@angular/router';
import { routes } from './app-routing.module'; // Importa as rotas do módulo de roteamento

export const appConfig: ApplicationConfig = {
  providers: [provideRouter(routes)] // Fornece o roteador usando as rotas importadas
};
