import {
  Component,
  Injector,
  OnInit,
  EventEmitter,
  Output,
} from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { forEach as _forEach, includes as _includes, map as _map } from 'lodash-es';
import { AppComponentBase } from '../../../shared/app-component-base';
import {
  ConfigureRuleServiceProxy,
  ConfigureRuleDto,
  EditConfigureRuleDto,
  PermissionDto,
  FlatPermissionDto
} from '../../../shared/service-proxies/service-proxies';

@Component({
  templateUrl: 'edit-ConfigureRule-dialog.component.html'
})
export class EditConfigureRuleDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  id: number;
  ConfigureRule = new EditConfigureRuleDto();

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    private _ConfigureRuleService: ConfigureRuleServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._ConfigureRuleService
      .get(this.id)
      .subscribe((result: ConfigureRuleDto) => {
        this.ConfigureRule = result;
      });
  }

  setInitialPermissionsStatus(): void {
  }

  isPermissionChecked(permissionName: string): boolean {
    return true;
  }

  onPermissionChange(permission: PermissionDto, $event) {

  }

  getCheckedPermissions(): string[] {

    return [];
  }

  save(): void {
    this.saving = true;
    const ConfigureRule = new ConfigureRuleDto();
    ConfigureRule.init(this.ConfigureRule);

    this._ConfigureRuleService
      .update(ConfigureRule)
      .pipe(
        finalize(() => {
          this.saving = false;
        })
      )
      .subscribe(() => {
        this.notify.info(this.l('SavedSuccessfully'));
        this.bsModalRef.hide();
        this.onSave.emit();
      });
  }
}
