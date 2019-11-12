
import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { ComboComponent } from './combo.component';

import { ComboContactComponent } from './combo.contact';
import { ComboLanguageComponent } from './combo.language';
import { ComboPersonComponent } from './combo.person';

@NgModule({
    declarations: [
        ComboComponent,
        ComboContactComponent,
        ComboLanguageComponent,
        ComboPersonComponent,
    ],
    imports: [
        SharedModule,
    ],
    exports: [
        ComboComponent,
        ComboContactComponent,
        ComboLanguageComponent,
        ComboPersonComponent,
    ]


})
export class CombosModule {

}


