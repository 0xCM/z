export type MsVsInstaller=''


const HelpDoc =
`
## SubCmd
install	Installs a product
update	Updates an installation
modify	Modifies an existing installation, adding and removing components
resume	Resume the installation
uninstall	Uninstalls an installation
repair	Repairs an installation
export	Exports an installation configuration file.
modifySettings	Modifies the settings of an existing installation
removeChannel	Removes a channel
updateAll	Updates all applicable installations
rollback	Rolls an installation back to its previously installed version

### export
    --productId	The ID of the product to export the installation configuration for.
    --channelId	The ID of the channel containing the product to export the installation configuration for.
    --channelUri	The URI or path to the channel manifest to use for updates
    --installChannelUri	The URI or path to the channel manifest to use for the installation
    --path	Sets the custom path using a key=value pair e.g. --path cache=C:\\cachePath
    --installPath	The path to the installation to use for exporting an installation configuration file.
    --config	The path to save the installation configuration file.
    --add	The component or workload ID to add
    --remove	The component or workload ID to remove
    --all	Adds all workloads and components
    --allWorkloads	Adds all workloads
    --includeRecommended	Includes all recommended components for workloads added
    --includeOptional	Includes all optional components for workloads added
    --passive, --p	The command executes immediately without user interaction, showing UI
    --quiet, --q	The command executes immediately without user interaction, without creating UI
    --campaign	The ID for campaign tracking
    --activityId	The ID of the related process that started the installer
    --devenvLaunchArguments	The arguments to pass on to devenv
    --in	The path to the response file to use for the operation
    --noUpdateInstaller	Prevents the installer from automatically updating if an update is required
    --cache	Specifies that payloads should be cached on the system
    --nocache	Specifies that payloads should be deleted from the system
    --noWeb	Prevents the installer from downloading any payloads
    --force	Forces any running, blocking exes to shutdown before starting the operation
    --installerFlight	Flights to enable for the installer, along with their duration e.g. flight1;7d
    --theme	Changes the color theme of the installer
    --locale	Sets the UI locale

### install    
    --path	Sets the custom path using a key=value pair e.g. --path cache=C:\\cachePath
    --flight	The flights to enable, along with their duration e.g. flight1;7d
    --clone	The install path of an installed product to clone
    --productKey	The license product key for the product. Composed of 25 alphanumeric characters either in the format 'xxxxx-xxxxx-xxxxx-xxxxx-xxxxx' or 'xxxxxxxxxxxxxxxxxxxxxxxxx'
    --nickname	The nickname to give the installation
    --focusedUi	Opens the installer in a focused installation mode
    --installCatalogUri	The URI or path to the catalog to use for the installation
    --installPath	The path where the product should be installed
    --installWhileDownloading	Enables parallel install and download
    --downloadThenInstall	Downloads all packages before installing
    --add	The component or workload ID to add
    --remove	The component or workload ID to remove
    --all	Adds all workloads and components
    --allWorkloads	Adds all workloads
    --includeRecommended	Includes all recommended components for workloads added
    --includeOptional	Includes all optional components for workloads added
    --addProductLang	Adds a product language to install
    --removeProductLang	Removes a product language
    --config	The path to a configuration file to use for selection
    --vsix	The URI or path to additional vsixs to install
    --removeOos	Removes all out-of-support workloads and components.
    --passive, --p	The command executes immediately without user interaction, showing UI
    --quiet, --q	The command executes immediately without user interaction, without creating UI
    --norestart	Prevents a quiet/passive operation from rebooting automatically, if required
    --channelUri	The URI or path to the channel manifest to use for updates
    --installChannelUri	The URI or path to the channel manifest to use for the installation
    --channelId	The ID of the channel containing the product to install
    --productId	The ID of the product to install
    --layoutPath	The path to the layout to use for installation packages
    --campaign	The ID for campaign tracking
    --activityId	The ID of the related process that started the installer
    --devenvLaunchArguments	The arguments to pass on to devenv
    --in	The path to the response file to use for the operation
    --noUpdateInstaller	Prevents the installer from automatically updating if an update is required
    --cache	Specifies that payloads should be cached on the system
    --nocache	Specifies that payloads should be deleted from the system
    --noWeb	Prevents the installer from downloading any payloads
    --force	Forces any running, blocking exes to shutdown before starting the operation
    --installerFlight	Flights to enable for the installer, along with their duration e.g. flight1;7d
    --theme	Changes the color theme of the installer
    --locale	Sets the UI locale
    
### modify
    --focusedUi	Opens the installer in a focused installation mode
    --flight	The flights to enable, along with their duration e.g. flight1;7d
    --installPath	The path to the installation to modify
    --installWhileDownloading	Enables parallel install and download
    --downloadThenInstall	Downloads all packages before installing
    --path	Sets the custom path using a key=value pair e.g. --path cache=C:\\cachePath
    --add	The component or workload ID to add
    --remove	The component or workload ID to remove
    --all	Adds all workloads and components
    --allWorkloads	Adds all workloads
    --includeRecommended	Includes all recommended components for workloads added
    --includeOptional	Includes all optional components for workloads added
    --addProductLang	Adds a product language to install
    --removeProductLang	Removes a product language
    --config	The path to a configuration file to use for selection
    --vsix	The URI or path to additional vsixs to install
    --removeOos	Removes all out-of-support workloads and components.
    --passive, --p	The command executes immediately without user interaction, showing UI
    --quiet, --q	The command executes immediately without user interaction, without creating UI
    --norestart	Prevents a quiet/passive operation from rebooting automatically, if required
    --channelUri	The URI or path to the channel manifest to use for updates
    --installChannelUri	The URI or path to the channel manifest to use for the installation
    --channelId	The ID of the channel containing the product to install
    --productId	The ID of the product to install
    --layoutPath	The path to the layout to use for installation packages
    --campaign	The ID for campaign tracking
    --activityId	The ID of the related process that started the installer
    --devenvLaunchArguments	The arguments to pass on to devenv
    --in	The path to the response file to use for the operation
    --noUpdateInstaller	Prevents the installer from automatically updating if an update is required
    --cache	Specifies that payloads should be cached on the system
    --nocache	Specifies that payloads should be deleted from the system
    --noWeb	Prevents the installer from downloading any payloads
    --force	Forces any running, blocking exes to shutdown before starting the operation
    --installerFlight	Flights to enable for the installer, along with their duration e.g. flight1;7d
    --theme	Changes the color theme of the installer
    --locale	Sets the UI locale

### modifySettings
    --installPath	The path to the installation to modify settings
    --channelUri	The URI or path to the channel manifest to use for updates
    --newChannelUri	The new URI or path to the channel manifest to use for updates
    --productId	The ID of the product to modify settings
    --passive, --p	The command executes immediately without user interaction, showing UI
    --quiet, --q	The command executes immediately without user interaction, without creating UI
    --removeOos	Removes all out-of-support workloads and components.
    --campaign	The ID for campaign tracking
    --activityId	The ID of the related process that started the installer
    --devenvLaunchArguments	The arguments to pass on to devenv
    --in	The path to the response file to use for the operation
    --noUpdateInstaller	Prevents the installer from automatically updating if an update is required
    --cache	Specifies that payloads should be cached on the system
    --nocache	Specifies that payloads should be deleted from the system
    --noWeb	Prevents the installer from downloading any payloads
    --force	Forces any running, blocking exes to shutdown before starting the operation
    --installerFlight	Flights to enable for the installer, along with their duration e.g. flight1;7d
    --theme	Changes the color theme of the installer
    --locale	Sets the UI locale
`
