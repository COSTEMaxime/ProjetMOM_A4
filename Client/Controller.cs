using Client.MiddlewareService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client {
    public class Controller {

        User userInfo;
        ApplicationInfo appInfo;
        MainView view;

        IAction action;

        public Controller(User userInfo, ApplicationInfo appInfo) {
            this.userInfo = userInfo;
            this.appInfo = appInfo;

            appInfo.Token = "client";

            InitView();
        }

        private void InitView() {
            view = new MainView(userInfo, appInfo, this);
            Application.Run(view);
        }

        private void responseValidator(Client.MiddlewareService.Message response) {
            if(response.operationStatus == false)
                view.appendConsole("[ERROR] ");

            view.appendConsole(response.info + "\n");
        }

        public void login() {
            action = new UserAction(new LoginMessenger(userInfo, appInfo));
            responseValidator(action.carryOut());
        }

        public void logout() {
            // action = new UserAction(new LogoutMessenger(userInfo, appInfo));
            // action.carryOut();
            throw new NotImplementedException();
        }

        public void register() {

            view.appendConsole("[DEBUG] Sending register request [username:" + userInfo.Username + ", password:" + userInfo.Password + "]\n");

            action = new UserAction(new RegisterMessenger(userInfo, appInfo));
            responseValidator(action.carryOut());
        }

        public void decodeFile() {
            action = new UserAction(new FileDecodeMessenger(userInfo, appInfo));
            responseValidator(action.carryOut());
        }
    }
}
