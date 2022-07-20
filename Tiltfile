SOURCE_IMAGE = os.getenv("SOURCE_IMAGE", default='ykhadilkar/blazor-app-default') # update registry
LOCAL_PATH = os.getenv("LOCAL_PATH", default='.')
NAMESPACE = os.getenv("NAMESPACE", default='default')
NAME = "blazor-app"

k8s_custom_deploy(
  NAME,
  apply_cmd="tanzu apps workload apply -f config/workload.yaml --debug --live-update" +
            " --local-path " + LOCAL_PATH +
            " --source-image " + SOURCE_IMAGE +
            " --namespace " + NAMESPACE +
            " --yes >/dev/null" +
            " && kubectl get workload " + NAME + " --namespace " + NAMESPACE + " -o yaml",
  delete_cmd="tanzu apps workload delete " + NAME + " --namespace " + NAMESPACE + " --yes",
  deps=['./bin'],
  container_selector='workload',
  live_update=[
    sync('./bin', '/workspace')
  ]
)

k8s_resource(NAME, port_forwards=["5193:5193"],
            extra_pod_selectors=[{'serving.knative.dev/service': 'blazor-app'}])

allow_k8s_contexts('tap-large') # update the context