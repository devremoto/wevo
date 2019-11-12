// models imports/////////////////////////////////
import { NgModule } from '@angular/core';

import { LanguageService } from './LanguageService';
import { PersonService } from './PersonService';

@NgModule({
  // provides
  providers: [
    LanguageService,
    PersonService,
  ]
})
export class ServiceGeneratedModule {

}
