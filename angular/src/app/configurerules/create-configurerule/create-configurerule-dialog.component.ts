import {
  Component,
  Injector,
  OnInit,
  EventEmitter,
  Output,
} from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { AppComponentBase } from '../../../shared/app-component-base';
import {
  ConfigureRuleServiceProxy,
  ConfigureRuleDto,
  PermissionDto,
  CreateConfigureRuleDto,
  PermissionDtoListResultDto
} from '../../../shared/service-proxies/service-proxies';
import { forEach as _forEach, map as _map } from 'lodash-es';

@Component({
  templateUrl: 'create-ConfigureRule-dialog.component.html'
})
export class CreateConfigureRuleDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  ConfigureRule = new ConfigureRuleDto();
  permissions: PermissionDto[] = [];
  checkedPermissionsMap: { [key: string]: boolean } = {};
  defaultPermissionCheckedStatus = true;

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    private _ConfigureRuleService: ConfigureRuleServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {

  }

  setInitialPermissionsStatus(): void {

  }

  isPermissionChecked(permissionName: string): boolean {
    // just return default permission checked status
    // it's better to use a setting
    return this.defaultPermissionCheckedStatus;
  }

  onPermissionChange(permission: PermissionDto, $event) {
    
  }

  getCheckedPermissions(): string[] {
    const permissions: string[] = [];

    return permissions;
  }

  save(): void {
    this.saving = true;

    const ConfigureRule = new CreateConfigureRuleDto();
    ConfigureRule.init(this.ConfigureRule);
    
    this._ConfigureRuleService
      .create(ConfigureRule)
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
