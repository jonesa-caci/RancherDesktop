# Start with a clean CentOS 7 base image
FROM centos:7

# Install required packages
RUN yum update -y && \
    yum install -y curl tar python3 python3-pip && \
    yum clean all

# Install Koji
RUN pip3 install --upgrade pip && \
    pip3 install pykube && \
    pip3 install psycopg2 && \
    pip3 install flask && \
    pip3 install koji

# Download k3s binary and extract it
RUN curl -L https://github.com/k3s-io/k3s/releases/download/v1.22.4%2Bk3s1/k3s -o /usr/local/bin/k3s && \
    chmod +x /usr/local/bin/k3s

# Set up k3s API registry server
RUN mkdir -p /var/lib/rancher/k3s/server/manifests && \
    touch /var/lib/rancher/k3s/server/manifests/api-registry.yaml && \
    echo 'kind: Service\n\
apiVersion: v1\n\
metadata:\n\
  name: k3s-registry\n\
  namespace: kube-system\n\
spec:\n\
  selector:\n\
    k8s-app: registry\n\
  ports:\n\
    - name: registry\n\
      port: 5000\n\
      targetPort: 5000\n\
  type: ClusterIP\n\
---\n\
apiVersion: apps/v1\n\
kind: Deployment\n\
metadata:\n\
  name: k3s-registry\n\
  namespace: kube-system\n\
spec:\n\
  selector:\n\
    matchLabels:\n\
      k8s-app: registry\n\
  replicas: 1\n\
  template:\n\
    metadata:\n\
      labels:\n\
        k8s-app: registry\n\
    spec:\n\
      containers:\n\
        - name: registry\n\
          image: registry:2\n\
          ports:\n\
            - containerPort: 5000\n\
          volumeMounts:\n\
            - name: registry-storage\n\
              mountPath: /var/lib/registry\n\
      volumes:\n\
        - name: registry-storage\n\
          emptyDir: {}\n\
' > /var/lib/rancher/k3s/server/manifests/api-registry.yaml

# Expose the k3s API registry server port
EXPOSE 5000

# Start the k3s API registry server
CMD ["sh", "-c", "koji --user=user --password=password --server=https://koji.example.com/ registry add k3s-registry https://localhost:5000/v2/_catalog && k3s server --disable-agent --docker --kube-apiserver-arg=storage-backend=etcd3 --kube-apiserver-arg=registry-suggests-reloads=false --kube-apiserver-arg=feature-gates=RotateKubeletServerCertificate=true --kube-apiserver-arg=feature-gates=RotateKubeletClientCertificate=true --kube-apiserver-arg=feature-gates=RotateServiceAccountToken=true --kube-apiserver-arg=service-account-signing-key-file=/var/lib/rancher/k3s/server/tls/service.key --kube-apiserver-arg=service-account-issuer=k3s --kube-apiserver-arg=service-account-api-audiences=https://kubernetes.default.svc.cluster.local,https://kubernetes.default.svc --kube-apiserver-arg=audit-log-path=/var/log/k3s/audit.log --kube-apiserver
