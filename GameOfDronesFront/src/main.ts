import { bootstrapApplication } from '@angular/platform-browser';
import { AppComponent } from './app/app.component'; // Ajuste conforme necessário
import { appConfig } from './app/app.config'; // Verifique se o caminho está correto
import { provideHttpClient } from '@angular/common/http';

bootstrapApplication(AppComponent, {
  providers: [
    appConfig.providers,
    provideHttpClient(),
  ],
});
